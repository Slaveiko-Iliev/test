using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class OxygenClimber : Climber
    {
        private const int _Stamina = 10;


        public OxygenClimber(string name) : base(name, _Stamina)
        {
        }

        public override void Rest(int daysCount)
        {
            this.Stamina += daysCount;
        }
    }
}
