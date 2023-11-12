namespace _03.Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int WarriorPower = 100;

        public Warrior(string name) : base(name)
        {
        }

        public override int Power => WarriorPower;

        public override string CastAbility() => $"{this.GetType().Name} - {Name} hit for {Power} damage";
    }
}
