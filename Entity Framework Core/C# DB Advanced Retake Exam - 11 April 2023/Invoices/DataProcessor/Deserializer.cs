namespace Invoices.DataProcessor
{
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ImportDto;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
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
            ImportInvoicesDto[] invoicesTmp = JsonConvert.DeserializeObject<ImportInvoicesDto[]>(jsonString)!;
            StringBuilder sb = new StringBuilder();

            int[] validIds = context.Clients.Select(c => c.Id).ToArray();

            var invoicesToImport = new List<Invoice>();

            foreach (var i in invoicesTmp)
            {
                bool isValidIssueDate = DateTime.TryParse(i.IssueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime issueDate);
                bool isValidDueDate = DateTime.TryParse(i.DueDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);

                if (!IsValid(i)
                    || !isValidIssueDate
                    || !isValidDueDate
                    || dueDate < issueDate
                    || i.Amount <= 0
                    || !validIds.Contains(i.ClientId)
                    )
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Invoice newInvoice = new Invoice()
                {
                    Id = i.Id,
                    Number = i.Number,
                    IssueDate = issueDate,
                    DueDate = dueDate,
                    Amount = i.Amount,
                    CurrencyType = (CurrencyType)i.CurrencyType,
                    ClientId = i.ClientId
                };
                invoicesToImport.Add(newInvoice);
                sb.AppendLine($"Successfully imported invoice with number {i.Number}.");
            }

            context.Invoices.AddRange(invoicesToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            ImportProductDto[] importProductDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(jsonString)!;
            StringBuilder sb = new StringBuilder();
            List<Product> productsToImport = new List<Product>();
            int[] validClientIds = context.Clients
                .Select(c => c.Id)
                .ToArray();

            foreach (var importProductDto in importProductDtos)
            {
                if (!IsValid(importProductDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product newProduct = new Product()
                {
                    Name = importProductDto.Name,
                    Price = importProductDto.Price,
                    CategoryType = (CategoryType)importProductDto.CategoryType
                };

                foreach (var dtoClientId in importProductDto.Clients.Distinct())
                {
                    if (!validClientIds.Contains(dtoClientId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ProductClient productClient = new ProductClient()
                    {
                        ClientId = dtoClientId,
                        Product = newProduct
                    };

                    newProduct.ProductsClients.Add(productClient);
                }
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, newProduct.Name, newProduct.ProductsClients.Count));
                productsToImport.Add(newProduct);
            }
            context.Products.AddRange(productsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
