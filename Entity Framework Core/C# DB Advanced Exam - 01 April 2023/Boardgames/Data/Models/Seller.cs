using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            BoardgamesSellers = new HashSet<BoardgameSeller>();
        }

        public int Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; } = null!;
        [MaxLength(30)]
        public string Address { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Website { get; set; } = null!;
        public ICollection <BoardgameSeller> BoardgamesSellers { get; set; }
    }
}

