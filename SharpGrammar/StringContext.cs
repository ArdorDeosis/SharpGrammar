using System;

namespace SharpGrammar
{
    // TODO: move to own space for string implementations
    public class StringContext : ContextBase<string>
    {
        public override string NullValue => "";
        public override Func<string, string, string> Concatenate => (lhs, rhs) => lhs + rhs;
    }
}