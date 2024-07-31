namespace Invoices.DataProcessor.ExportDto
{
    public class ExportProductsClientsDto
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
        public ClientDto[] Clients { get; set; } = null!;
    }

    public class ClientDto
    {
        public string Name { get; set; } = null!;
        public string NumberVat { get; set; } = null!;
    }
}

