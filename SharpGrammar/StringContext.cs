using System;

namespace SharpGrammar
{
    // TODO: this should not be in the generic package
    public class StringContext : Context<string>
    {
        public override string NullValue => "";
        public override Func<string, string, string> Concatenate => (lhs, rhs) => lhs + rhs;
    }
}