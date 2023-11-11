using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public abstract int Power { get; }

        public abstract string CastAbility();
    }
}
