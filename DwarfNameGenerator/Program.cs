using System;
using SharpGrammar;

namespace DwarfNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 200; i++)
            {
                Console.Write(DwarfNameGrammar.DwarfName.Process(new StringContext()) + ", ");
            }
        }
    }
}