namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.DataProcessor.ExportDtos;
    using System.Globalization;
    using Trucks.Utilities;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            bool isValidDate = DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime productionDate);
            XmlHelper xmlHelper = new XmlHelper();

            Patient[] tmp = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > productionDate))
                .ToArray();

            ExportPatientDto[] patientsToExport = tmp
                .Select(p => new ExportPatientDto()
                {
                    Gender = p.Gender.ToString().ToLower(),
                    Name = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Medicines = p.PatientsMedicines.Select(pm => new MedicineDto()
                    {
                        Name = pm.Medicine.Name,
                        Price = pm.Medicine.Price.ToString("f2"),
                        Producer = pm.Medicine.Producer,
                        BestBefore = pm.Medicine.ExpiryDate,
                        Category = pm.Medicine.Category.ToString()
                    })
                                                    .OrderByDescending(m => m.BestBefore)
                                                    .ThenBy(m => m.Price)
                                                    .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.Name)
                .ToArray();

            return xmlHelper.Serialize(patientsToExport, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {

        }
    }
}
