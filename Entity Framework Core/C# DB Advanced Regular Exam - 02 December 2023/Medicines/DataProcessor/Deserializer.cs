namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Microsoft.EntityFrameworkCore.Infrastructure;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";



        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportPharmacyDto[]), new XmlRootAttribute("Pharmacies"));
            using StringReader reader = new StringReader(xmlString);
            ImportPharmacyDto[] importedPharmacyDtos = (ImportPharmacyDto[])xmlSerializer.Deserialize(reader);

            List<Pharmacy> pharmacies = new List<Pharmacy>();
            StringBuilder sb = new StringBuilder();

            foreach (var pha in importedPharmacyDtos)
            {
                bool parseIsNonStop = bool.TryParse(pha.IsNonStop, out bool isNonStop);

                if (!IsValid(pha)
                    || !parseIsNonStop)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy newPharmacy = new Pharmacy()
                {
                    Name = pha.Name,
                    PhoneNumber = pha.PhoneNumber,
                    IsNonStop = isNonStop
                };

                foreach (var med in pha.Medicines)
                {
                    bool isValidProductionDate = DateTime.TryParseExact(med.ProductionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime productionDate);
                    bool isValidExpiryDate = DateTime.TryParseExact(med.ExpiryDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiryDate);
                    bool parseCategory = int.TryParse(med.Category, out int category);

                    if (!IsValid(med)
                        || med.Price <= 0
                        || !isValidProductionDate
                        || !isValidExpiryDate
                        || productionDate >= expiryDate
                        || newPharmacy.Medicines.Any(m => m.Name == med.Name && m.Producer == med.Producer
                        || !parseCategory
                        || category < 0
                        || category > 4))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine newMedicine = new Medicine()
                    {
                        Name = med.Name,
                        Price = med.Price,
                        Category = (Category)category,
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = med.Producer
                    };
                    newPharmacy.Medicines.Add(newMedicine);
                }
                pharmacies.Add(newPharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, newPharmacy.Name, newPharmacy.Medicines.Count));
            }
            context.Pharmacies.AddRange(pharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            ImportPatientDto[] patientDtos = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            ICollection<Patient> patientsToImport = new List<Patient>();

            foreach (var patientDto in patientDtos)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient newPatient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender
                };

                foreach (var medicine in patientDto.Medicines)
                {
                    if (newPatient.PatientsMedicines.Any(pm => pm.MedicineId == medicine))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = newPatient,
                        MedicineId = medicine
                    };

                    newPatient.PatientsMedicines.Add(patientMedicine);
                }
                patientsToImport.Add(newPatient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, newPatient.FullName, newPatient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(patientsToImport);
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
