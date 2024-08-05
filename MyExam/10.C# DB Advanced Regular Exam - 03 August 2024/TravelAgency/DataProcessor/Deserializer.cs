using Castle.Core.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;
using TravelAgency.Utilities;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, "Customers");

            StringBuilder sb = new StringBuilder();

            var customersInBase = context.Customers;
            List<Customer> customerToImport = new List<Customer>();

            foreach (var cd in customerDtos)
            {
                if (!IsValid(cd))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (customersInBase.Any(cib => cib.FullName == cd.FullName
                                            || cib.Email == cd.Email
                                            || cib.PhoneNumber == cd.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }
                if (customerToImport.Any(cib => cib.FullName == cd.FullName
                            || cib.Email == cd.Email
                            || cib.PhoneNumber == cd.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer newCustomer = new Customer()
                {
                    FullName = cd.FullName,
                    Email = cd.Email,
                    PhoneNumber = cd.PhoneNumber
                };

                customerToImport.Add(newCustomer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, newCustomer.FullName));
            }

            context.Customers.AddRange(customerToImport);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            ImportBookingDto[] bookingDtos = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            Customer[] customersInBase = context.Customers
                .ToArray();
            TourPackage[] tourPackageInBase = context.TourPackages
                .ToArray();
            List<Booking> bookingsToImport = new List<Booking>();

            foreach (var bd in bookingDtos)
            {
                if (!IsValid(bd))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                bool isValidBookingDate = DateTime.TryParseExact(bd.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var bookingDate);

                if (!isValidBookingDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking newBooking = new Booking()
                {
                    BookingDate = bookingDate,
                    Customer = customersInBase.Find(c => c.FullName == bd.CustomerName),
                    TourPackage = tourPackageInBase.Find(c => c.PackageName == bd.TourPackageName)
                };

                bookingsToImport.Add(newBooking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, newBooking.TourPackage.PackageName, newBooking.BookingDate.ToString("yyyy-MM-dd")));
            }
            context.Bookings.AddRange(bookingsToImport);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
