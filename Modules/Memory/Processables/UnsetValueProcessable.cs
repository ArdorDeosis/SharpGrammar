using System;

namespace SharpGrammar.Memory
{
    internal class UnsetValueProcessable<T> : Processable<T>
    {
        private readonly string name;
        internal UnsetValueProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            context.Get<IMemoryModule<T>>().UnsetValue(name);
            return context.NullValue;
        }
    }
}