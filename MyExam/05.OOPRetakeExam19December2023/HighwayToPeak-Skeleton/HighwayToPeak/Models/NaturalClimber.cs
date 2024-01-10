using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int _Stamina = 6;


        public NaturalClimber(string name) : base(name, _Stamina)
        {
        }

        public override void Rest(int daysCount)
        {
            this.Stamina += daysCount * 2;
        }
    }
}
