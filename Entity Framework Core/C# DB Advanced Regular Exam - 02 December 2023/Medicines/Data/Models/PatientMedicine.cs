using Medicines.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
    public class PatientMedicine
    {
        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;
        public int MedicineId { get; set; }
        [ForeignKey(nameof(MedicineId))]
        public Medicine Medicine { get; set; } = null!;
    }
}

//⦁	PatientId – integer, Primary Key, foreign key (required)
//⦁	Patient – Patient
//⦁	MedicineId – integer, Primary Key, foreign key (required)
//⦁	Medicine – Medicine
