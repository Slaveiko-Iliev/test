namespace Handball.Models
{
    public class Goalkeeper : Player
    {
        private const double _Rating = 2.5;

        public Goalkeeper(string name) : base(name, _Rating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 1.25;
            if (Rating < 1)
            {
                base.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            Rating += 0.75;
            if (Rating > 10)
            {
                base.Rating = 10;
            }
        }
    }
}