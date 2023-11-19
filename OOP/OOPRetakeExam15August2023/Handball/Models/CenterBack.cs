namespace Handball.Models
{
    public class CenterBack : Player
    {
        private const double _Rating = 4;

        public CenterBack(string name) : base(name, _Rating)
        {
        }

        public override void DecreaseRating()
        {
            Rating -= 1;
            if (Rating < 1)
            {
                base.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            Rating += 1;
            if (Rating > 10)
            {
                base.Rating = 10;
            }
        }
    }
}
