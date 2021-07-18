using System;
using SharpGrammar;

namespace DwarfNameGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            var context = new Context()
                .BindTypeHandler(new StringHandler());
            
            for (var i = 0; i < 144; i++)
                Console.WriteLine(DwarfNameGrammar.Name.Process(context));
        }
    }
}