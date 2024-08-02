using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        public Pharmacy()
        {
            Medicines = new HashSet<Medicine>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(14)]
        public string PhoneNumber { get; set; } = null!;
        public bool IsNonStop { get; set; }
        public ICollection<Medicine> Medicines { get; set; }
    }
}
 
