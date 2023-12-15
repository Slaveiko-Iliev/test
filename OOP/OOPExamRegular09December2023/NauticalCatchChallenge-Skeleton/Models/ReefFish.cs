namespace NauticalCatchChallenge.Models
{
    public class ReefFish : Fish
    {
        private const int _TimeToCatch = 30;

        public ReefFish(string name, double points) : base(name, points, _TimeToCatch)
        {
        }
    }
}
