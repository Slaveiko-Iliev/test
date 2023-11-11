namespace _03.Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int DruidPower = 80;

        public Druid(string name) : base(name)
        {
        }

        public override int Power => DruidPower;

        public override string CastAbility() => $"{GetType().Name} - {Name} healed for {Power}";
    }
}
