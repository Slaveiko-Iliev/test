using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [MinLength(5)]
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [MinLength(2)]
        [MaxLength(30)]
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;
        [RegularExpression("^(www\\.)[a-zA-Z0-9-]*(\\.com)$")]
        public string Website { get; set; } = null!;
        public int[] Boardgames { get; set; }
    }
}
