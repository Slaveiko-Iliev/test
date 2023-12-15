namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        public const int _OxygenLevel = 540;

        public ScubaDiver(string name) : base(name, _OxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            OxygenLevel = _OxygenLevel;
        }
    }
}
