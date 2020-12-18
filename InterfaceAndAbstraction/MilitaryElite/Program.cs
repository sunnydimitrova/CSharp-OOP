using MilitaryElite.Core;
using MilitaryElite.IO;
using MilitaryElite.IO.Contracts;
using System;

namespace MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEngine engine = new Engine(reader, writer);
            engine.Run();
        }
    }
}
