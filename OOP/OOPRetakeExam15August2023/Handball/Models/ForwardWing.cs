namespace Handball.Models
{
    public class ForwardWing : Player
    {
        private const double _Rating = 5.5;

        public ForwardWing(string name) : base(name, _Rating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 0.75;
            if (Rating < 1)
            {
                base.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            Rating += 1.25;
            if (Rating > 10)
            {
                base.Rating = 10;
            }
        }
    }
}
