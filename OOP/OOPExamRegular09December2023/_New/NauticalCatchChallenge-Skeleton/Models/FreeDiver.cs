namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int _OxygenLevel = 120;
        private const double _DecreaseOxygenLevel = 0.6;

        public FreeDiver(string name) : base(name, _OxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch) => OxygenLevel -= (int)Math.Round(_DecreaseOxygenLevel * TimeToCatch, MidpointRounding.AwayFromZero);

        public override void RenewOxy() => this.OxygenLevel = _OxygenLevel;
    }
}
