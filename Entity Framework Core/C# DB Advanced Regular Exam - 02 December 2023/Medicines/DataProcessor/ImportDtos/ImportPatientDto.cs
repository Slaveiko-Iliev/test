using Medicines.Data.Models.Enums;
using Medicines.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientDto
    {
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Range(0,2)]
        public int AgeGroup { get; set; }
        [Range(0,1)]
        public int Gender { get; set; }
        public int[] Medicines { get; set; }
    }
}
