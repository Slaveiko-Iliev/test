using _03.Raiding.Factories.Interfaces;
using _03.Raiding.Models;
using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Factories
{
    public class BaseHeroFactory : IBaseHeroFactory
    {
        public IBaseHero CreateHero(string type, string name)
        {
            switch (type)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new ArgumentException("Invalid hero!");
            }
        }
    }
}
