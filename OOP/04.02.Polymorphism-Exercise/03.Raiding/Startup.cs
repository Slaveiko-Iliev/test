using _03.Raiding.Core;
using _03.Raiding.Core.Interfaces;
using _03.Raiding.Factories;
using _03.Raiding.Factories.Interfaces;
using _03.Raiding.IO;
using _03.Raiding.IO.Interfaces;

IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();

IBaseHeroFactory heroFactory = new BaseHeroFactory();

IEngine engine = new Engine(reader, writer, heroFactory);

engine.Run();
