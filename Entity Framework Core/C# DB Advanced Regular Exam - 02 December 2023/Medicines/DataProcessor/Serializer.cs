namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Newtonsoft.Json;
    using System.Globalization;
    using Trucks.Utilities;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            bool isValidDate = DateTime.TryParse(date, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime productionDate);
            XmlHelper xmlHelper = new XmlHelper();

            ExportPatientDto[] patientsToExport = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > productionDate))
                .Select(p => new ExportPatientDto()
                {
                    Gender = p.Gender.ToString().ToLower(),
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines
                    .Where(pm => pm.Medicine.ProductionDate >= productionDate)
                    .Select(pm => pm.Medicine)
                    .OrderByDescending(m => m.ExpiryDate)
                    .ThenBy(m => m.Price)
                    .Select(m => new MedicineDto()
                    {
                        Name = m.Name,
                        Price = m.Price.ToString("f2"),
                        Producer = m.Producer,
                        BestBefore = m.ExpiryDate.ToString("yyyy-MM-dd"),
                        Category = m.Category.ToString().ToLower()
                    })
                                                    
                                                    .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToArray();

            return xmlHelper.Serialize(patientsToExport, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {;
            ExportMedicineDto[] medicineDtos = context.Medicines
                .Where(m => m.Category == (Category)medicineCategory
                            && m.Pharmacy.IsNonStop)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new ExportMedicineDto()
                {
                                    Name = m.Name,
                                    Price = m.Price.ToString("f2"),
                                    Pharmacy = new PharmacyDto()
                                    {
                                        Name = m.Pharmacy.Name,
                                        PhoneNumber = m.Pharmacy.PhoneNumber
                                    }
                })
                .ToArray();

            return JsonConvert.SerializeObject(medicineDtos, Formatting.Indented);
        }
    }
}
