using Invoices.Data.Models;
using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        InvoiceDto[] Invoices { get; set; }
    }

    [XmlType("Invoices")]
    public class InvoiceDto
    {
        [XmlElement]
        public int InvoiceNumber { get; set; }
        [XmlElement]
        public decimal InvoiceAmount { get; set; }
        [XmlElement]
        public DateTime DueDate { get; set; }
        [XmlElement]
        public CurrencyType Currency { get; set; }
    }
}
