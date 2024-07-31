using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType(nameof(Client))]
    public class ExportClientsWithInvoices
    {
        [XmlAttribute]
        public int InvoicesCount { get; set; }
        [XmlElement]
        public string ClientName { get; set; }
        [XmlElement]
        public string VatNumber { get; set; }
        [XmlArray]
        public InvoiceDto[] Invoices { get; set; }
    }

    [XmlType("Invoices")]
    public class InvoiceDto
    {
        [XmlElement]
        public int InvoiceNumber { get; set; }
        [XmlElement]
        public decimal InvoiceAmount { get; set; }
        [XmlElement]
        public string DueDate { get; set; }
        [XmlElement]
        public CurrencyType Currency { get; set; }
    }
}
