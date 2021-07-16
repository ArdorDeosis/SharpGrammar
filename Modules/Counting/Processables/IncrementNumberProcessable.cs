using System;

namespace SharpGrammar.Counting
{
    internal record IncrementNumberProcessable<T> : Processable<T>
    {
        private readonly string name;
        private readonly int value;
        internal IncrementNumberProcessable(string name, int value)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.value = value;
        }

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            if (!context.Get<INumberModule<T>>().TryGetNumber(name, out var oldValue))
                throw new GrammarProcessingException(nameof(IncrementNumberProcessable<T>),
                    $"Number '{name}' does not exist in the current context.");
            context.Get<INumberModule<T>>().SetNumber(name, oldValue + value);
            return context.NullValue<T>();
        }
    }
}