using System;
using SharpGrammar;

namespace DwarfNameGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            for (int i = 0; i < 200; i++)
                Console.Write(DwarfNameGrammar.DwarfName.Process() + ", ");
        }
    }
}