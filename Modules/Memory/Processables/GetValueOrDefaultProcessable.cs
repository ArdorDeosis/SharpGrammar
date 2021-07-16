using System;

namespace SharpGrammar.Memory
{
    internal record GetValueOrDefaultProcessable<T> : Processable<T>
    {
        private readonly string name;
        private readonly Processable<T> defaultValue;
        internal GetValueOrDefaultProcessable(string name, Processable<T> defaultValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.defaultValue = defaultValue  ?? throw new ArgumentNullException(nameof(defaultValue));
        }

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            return context.Get<IMemoryModule<T>>().TryGetValue(name, out Processable<T>? processable)
                ? processable!.Process(context)
                : defaultValue.Process(context);
        }
    }
}