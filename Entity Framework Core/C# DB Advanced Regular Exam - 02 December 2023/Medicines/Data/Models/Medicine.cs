using Medicines.Data.Models;
using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
    public class Medicine
    {
        public Medicine()
        {
            PatientsMedicines = new HashSet<PatientMedicine>();
        }

        public int Id { get; set; }
        [MaxLength(150)]
        public string Name { get; set; } = null!;
        [RegularExpression(@"^\d{1,18}(\.\d{1,2})?$")]
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        [MaxLength(100)]
        public string Producer { get; set; } = null!;
        [ForeignKey(nameof(Pharmacy))]
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; } = null!;
        public ICollection<PatientMedicine> PatientsMedicines { get; set; }
    }
}


