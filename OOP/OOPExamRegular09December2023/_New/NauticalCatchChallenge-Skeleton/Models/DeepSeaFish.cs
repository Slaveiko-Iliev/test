namespace NauticalCatchChallenge.Models
{
    public class DeepSeaFish : Fish
    {
        private const int _TimeToCatch = 180;

        public DeepSeaFish(string name, double points) : base(name, points, _TimeToCatch)
        {
        }
    }
}
