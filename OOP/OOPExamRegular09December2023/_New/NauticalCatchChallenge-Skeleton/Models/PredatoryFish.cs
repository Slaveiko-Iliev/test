namespace NauticalCatchChallenge.Models
{
    public class PredatoryFish : Fish
    {
        private const int _TimeToCatch = 60;

        public PredatoryFish(string name, double points) : base(name, points, _TimeToCatch)
        {
        }
    }
}
