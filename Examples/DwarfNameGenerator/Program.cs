using System;
using SharpGrammar;

namespace DwarfNameGenerator
{
    internal static class Program
    {
        private static void Main()
        {
            var context = new Context()
                .BindTypeHandling(new StringHandler());
            for (var i = 0; i < 200; i++)
                Console.Write(DwarfNameGrammar.DwarfName.Process(context) + ", ");
        }
    }

    public class StringHandler : ITypeHandler<string>
    {
        public string NullValue => "";

        public string Concatenate(string lhs, string rhs) => lhs + rhs;
    }
}