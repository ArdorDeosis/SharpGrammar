using SharpGrammar;

namespace DwarfNameGenerator
{
    public class StringHandler : ITypeHandler<string>
    {
        public string NullValue => "";

        public string Concatenate(string lhs, string rhs) => lhs + rhs;
    }
}