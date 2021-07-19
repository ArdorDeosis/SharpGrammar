using System;
using SharpGrammar;
using SharpGrammar.Counting;
using SharpGrammar.Memory;

namespace DwarfNameGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            var context = new Context()
                .BindTypeHandler(new StringHandler())
                .BindTypeHandler(new UnitSpecializationHandler())
                .BindModule<IMemoryModule>(new MemoryModule())
                .BindModule<INumberModule>(new NumberModule());
            
            Console.WriteLine(DwarfUnit.Unit.Process(context));
        }
    }
}