namespace Invoices.DataProcessor
{
    using Invoices.Common;
    using Invoices.Data;
    using Invoices.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Trucks.Utilities;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            throw new NotImplementedException();

        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {
            ExportProductsClientsDto[] productsToExport = context.Products
                .Where(p => p.ProductsClients.Any())
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .Select(p => new ExportProductsClientsDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                        .Where(pc => pc.Client.Name.Length >= nameLength)
                        .Select(pc => new ClientDto
                             {
                                 Name = pc.Client.Name,
                                 NumberVat = pc.Client.NumberVat
                             })
                        .OrderBy(c => c.Name)
                        .ToArray()
                })
                .OrderByDescending(p => p.Clients.Length)
                .ThenBy(p => p.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(productsToExport, Formatting.Indented);
        }

        private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
        {
            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture))
            {
                XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
                xmlSerializerNamespaces.Add(string.Empty, string.Empty);

                try
                {
                    xmlSerializer.Serialize(stringWriter, dto, xmlSerializerNamespaces);
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return stringBuilder.ToString();
        }
    }
}