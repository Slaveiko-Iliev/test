using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportGuidesWithSpanishDto[] guidesToExport = context.Guides
                .Where(g => g.Language == Language.Spanish)
                .Select(g => new ExportGuidesWithSpanishDto()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides.Select(tpg => new ExportTourPackageDto()
                    {
                        Name = tpg.TourPackage.PackageName,
                        Description = tpg.TourPackage.Description,
                        Price = tpg.TourPackage.Price
                    })
                    .OrderByDescending(p => p.Price)
                    .ThenBy(p => p.Name)
                    .ToArray()
                })
                .OrderByDescending(eg => eg.TourPackages.Length)
                .ThenBy(eg => eg.FullName)
                .ToArray();

            return xmlHelper.Serialize(guidesToExport, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {


            CustomersWithHorseRiding[] customersToExport = context.Bookings
                .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                .OrderBy(b => b.BookingDate)
                .Select(b => new CustomersWithHorseRiding()
                {
                    FullName = b.Customer.FullName,
                    PhoneNumber = b.Customer.PhoneNumber,
                    Bookings = b.TourPackage.Bookings
                    .Select(tp => new ExportBookingDto()
                    {
                        TourPackageName = tp.TourPackage.PackageName,
                        Date = b.BookingDate.ToString("yyyy-MM-dd")
                    })
                .Take(1)
                    .ToArray()
                })
                .OrderByDescending(c => c.Bookings.Length)
                .ThenBy(c => c.FullName)
                .ToArray();

            return JsonConvert.SerializeObject(customersToExport, Formatting.Indented);
        }
    }
}
