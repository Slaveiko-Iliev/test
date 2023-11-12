namespace _03.Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int RoguePower = 80;

        public Rogue(string name) : base(name)
        {
        }

        public override int Power => RoguePower;

        public override string CastAbility() => $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
