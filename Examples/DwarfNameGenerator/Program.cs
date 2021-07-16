using System;
using SharpGrammar;

namespace DwarfNameGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            var context = new Context().BindTypeHandling(new StringContext());
            for (var i = 0; i < 200; i++)
                Console.Write(DwarfNameGrammar.DwarfName.Process(context) + ", ");
        }
    }

    public class StringContext : ITypeContext<string>
    {
        public string NullValue => "";
        public Func<string, string, string> Concatenate => (lhs, rhs) => lhs + rhs;
    }
}