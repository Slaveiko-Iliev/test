namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int _OxygenLevel = 540;
        private const double _DecreaseOxygenLevel = 0.3;

        public ScubaDiver(string name) : base(name, _OxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch) => OxygenLevel -= (int)Math.Round(_DecreaseOxygenLevel * TimeToCatch, MidpointRounding.AwayFromZero);

        public override void RenewOxy() => this.OxygenLevel = _OxygenLevel;
    }
}
