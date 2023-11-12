namespace _03.Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int PaladinPower = 100;

        public Paladin(string name) : base(name)
        {
        }

        public override int Power => PaladinPower;

        public override string CastAbility() => $"{this.GetType().Name} - {Name} healed for {Power}";
    }
}
