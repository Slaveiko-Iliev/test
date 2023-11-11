using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Factories.Interfaces
{
    public interface IBaseHeroFactory
    {
        IBaseHero CreateHero(string type, string name);
    }
}
