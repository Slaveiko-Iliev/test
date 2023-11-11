using _03.Raiding.Core.Interfaces;
using _03.Raiding.Factories.Interfaces;
using _03.Raiding.IO.Interfaces;
using _03.Raiding.Models.Interfaces;

namespace _03.Raiding.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IBaseHeroFactory heroFactory;

    public Engine(
        IReader reader,
        IWriter writer,
        IBaseHeroFactory heroFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroFactory = heroFactory;
    }

    public void Run()
    {
        List<IBaseHero> heroes = new();

        int number = int.Parse(reader.ReadLine());

        for (int i = 0; i < number; i++)
        {
            try
            {
                string name = reader.ReadLine();
                string type = reader.ReadLine();

                IBaseHero hero = heroFactory.CreateHero(type, name);
                heroes.Add(hero);
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
            }
        }

        int bossPower = int.Parse(reader.ReadLine());

        foreach (var hero in heroes)
        {
            writer.WriteLine(hero.CastAbility());
            bossPower -= hero.Power;
        }

        if (bossPower <= 0)
        {
            writer.WriteLine("Victory!");
        }
        else
        {
            writer.WriteLine("Defeat...");
        }
    }
}
