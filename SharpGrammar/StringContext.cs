using System;

namespace SharpGrammar
{
    /// <summary>
    /// A context for string-producing grammars.
    /// </summary>
    public class StringContext : ContextBase<string>
    {
        public override string NullValue => "";
        public override Func<string, string, string> Concatenate => (lhs, rhs) => lhs + rhs;

        public StringContext()
        {
        }

        public StringContext(int seed) : base(seed)
        {
        }
    }
}