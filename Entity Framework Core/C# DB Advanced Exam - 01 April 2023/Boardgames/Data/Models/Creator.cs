using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            Boardgames = new HashSet<Boardgame>();
        }

        public int Id { get; set; }
        [MaxLength(7)]
        public string FirstName { get; set; } = null!;
        [MaxLength(7)]
        public string LastName { get; set; } = null!;
        public ICollection<Boardgame> Boardgames { get; set; }
    }
}


