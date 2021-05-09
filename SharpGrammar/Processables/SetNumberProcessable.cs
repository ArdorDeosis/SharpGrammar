using System;

namespace SharpGrammar
{
    internal class SetNumberProcessable : Processable
    {
        private readonly string name;
        private readonly int value;
        private readonly bool overrideExistingValue;
        
        internal SetNumberProcessable(string name, int value, bool overrideExistingValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.value = value;
            this.overrideExistingValue = overrideExistingValue;
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            context.SetNumber(name, value, overrideExistingValue);
            return context.NullValue;
        }
    }
}