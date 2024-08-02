﻿using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            PatientsMedicines = new HashSet<PatientMedicine>();
        }

        public int Id { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        public AgeGroup AgeGroup { get; set; }
        public Gender Gender { get; set; }
        public ICollection<PatientMedicine> PatientsMedicines { get; set; }
    }
}

