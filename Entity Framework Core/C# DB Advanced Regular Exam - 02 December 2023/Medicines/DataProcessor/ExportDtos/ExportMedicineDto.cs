using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Medicines.DataProcessor.ExportDtos
{
    public class ExportMedicineDto
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public PharmacyDto Pharmacy { get; set; }
    }

    public class PharmacyDto
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
