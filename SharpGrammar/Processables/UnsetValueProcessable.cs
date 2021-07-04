using System;

namespace SharpGrammar
{
    internal class UnsetValueProcessable : Processable
    {
        private readonly string name;
        internal UnsetValueProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            context.Get<IMemoryModule>().UnsetValue(name);
            return context.NullValue;
        }
    }
}