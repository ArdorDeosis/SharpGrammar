using System;
using SharpGrammar;

namespace DwarfNameGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            var context = new StringContext();
            for (var i = 0; i < 200; i++)
                Console.Write(DwarfNameGrammar.DwarfName.Process(context) + ", ");
        }
    }
}