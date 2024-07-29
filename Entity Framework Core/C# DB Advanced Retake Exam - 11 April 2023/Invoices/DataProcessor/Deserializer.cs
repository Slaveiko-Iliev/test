namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportClientDto[]), new XmlRootAttribute("Clients"));

            using StringReader xmlReader = new StringReader(xmlString);

            ImportClientDto[] clientDtos = (ImportClientDto[])xmlSerializer.Deserialize(xmlReader);

            StringBuilder sb = new StringBuilder();

            List<Client> clients = new List<Client>();

            foreach (var cd in clientDtos)
            {
                if (!IsValid(cd))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                try
                {
                    Client client = new Client()
                    {
                        Name = cd.Name,
                        NumberVat = cd.NumberVat
                    };

                    foreach (var a in cd.Addresses)
                    {
                        if (!IsValid(a))
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }

                        Address aAddress = new Address()
                        {
                            StreetName = a.StreetName,
                            StreetNumber = a.StreetNumber,
                            PostCode = a.PostCode,
                            City = a.City,
                            Country = a.Country
                        };

                        client.Addresses.Add(aAddress);
                    }

                    clients.Add(client);

                    sb.AppendLine($"Successfully imported client {client.Name}.");
                }
                catch (Exception)
                {

                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Clients.AddRange(clients);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            Invoice[] invoicesTmp = JsonConvert.DeserializeObject<Invoice[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Invoice> invoices = new List<Invoice>();

            foreach (var i in invoicesTmp)
            {
                if (!IsValid(i)
                    || i.DueDate < i.IssueDate
                    || i.Amount <= 0
                    //|| !context.Clients.Select(c => c.Id).Contains(i.Id)
                    )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                invoices.Add(i);
                sb.AppendLine($"Successfully imported invoice with number {i.Number}.");
            }

            context.Invoices.AddRange(invoices);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {


            throw new NotImplementedException();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
