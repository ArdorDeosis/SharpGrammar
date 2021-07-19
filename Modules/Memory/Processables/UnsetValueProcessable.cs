using System;

namespace SharpGrammar.Memory
{
    internal record UnsetValueProcessable<T> : Processable
    {
        private readonly string name;
        internal UnsetValueProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override void Process(IContext context) => context.Get<IMemoryModule>().UnsetValue<T>(name);
    }
}