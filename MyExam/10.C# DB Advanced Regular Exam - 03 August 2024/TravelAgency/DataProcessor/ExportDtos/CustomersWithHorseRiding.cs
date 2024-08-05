namespace TravelAgency.DataProcessor.ExportDtos
{
    public class CustomersWithHorseRiding
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public ExportBookingDto[] Bookings { get; set; }
    }

    public class ExportBookingDto
    {
        public string TourPackageName { get; set; }
        public string Date { get; set; }
    }
}
