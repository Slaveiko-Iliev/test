namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;
    using Trucks.Utilities;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportDespatcherDto[] despatcherDtos = xmlHelper.Deserialize<ImportDespatcherDto[]>(xmlString, "Despatchers");

            StringBuilder sb = new StringBuilder();
            List<Despatcher> despatchersToImport = new List<Despatcher>();

            foreach (var dd in despatcherDtos)
            {
                if (!IsValid(dd))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dd.Position == "")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Despatcher newDespatcher = new Despatcher()
                {
                    Name = dd.Name,
                    Position = dd.Position,
                };

                foreach (var t in dd.Trucks)
                {
                    if (!IsValid(t))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = t.RegistrationNumber,
                        VinNumber = t.VinNumber,
                        TankCapacity = t.TankCapacity,
                        CargoCapacity = t.CargoCapacity,
                        CategoryType = (CategoryType)t.CategoryType,
                        MakeType = (MakeType)t.MakeType
                    };

                    newDespatcher.Trucks.Add(truck);
                }

                despatchersToImport.Add(newDespatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, newDespatcher.Name, newDespatcher.Trucks.Count));
            }
            context.Despatchers.AddRange(despatchersToImport);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            ImportClientDto[] clientDtos = JsonConvert.DeserializeObject<ImportClientDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Client> clientToImport = new List<Client>();
            int[] validTruckIds = context.Trucks
                .Select(x => x.Id)
                .ToArray();

            foreach (var cd in clientDtos)
            {
                if (!IsValid(cd) || cd.Type == "usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client newClient = new Client()
                {
                    Name = cd.Name,
                    Nationality = cd.Nationality,
                    Type = cd.Type,
                };

                clientToImport.Add(newClient);

                foreach (var id in cd.Trucks.Distinct())
                {
                    if (!validTruckIds.Contains(id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck clientTruck = new ClientTruck()
                    {
                        TruckId = id,
                        Client = newClient
                    };

                    newClient.ClientsTrucks.Add(clientTruck);
                }

                clientToImport.Add(newClient);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, newClient.Name, newClient.ClientsTrucks.Count));
            }

            context.Clients.AddRange(clientToImport);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}