using System;

namespace SharpGrammar.Memory
{
    internal record UnsetValueProcessable<T> : Processable<T>
    {
        private readonly string name;
        internal UnsetValueProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            context.Get<IMemoryModule<T>>().UnsetValue(name);
            return context.GetNullValue<T>();
        }
    }
}