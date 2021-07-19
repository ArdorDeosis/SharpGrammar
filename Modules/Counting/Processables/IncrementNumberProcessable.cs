using System;

namespace SharpGrammar.Counting
{
    internal record IncrementNumberProcessable : Processable
    {
        private readonly string name;
        private readonly int value;
        internal IncrementNumberProcessable(string name, int value)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.value = value;
        }

        /// <inheritdoc />
        public override void Process(IContext context)
        {
            if (!context.Get<INumberModule>().TryGetNumber(name, out var oldValue))
                throw new GrammarProcessingException(nameof(IncrementNumberProcessable),
                    $"Number '{name}' does not exist in the current context.");
            context.Get<INumberModule>().SetNumber(name, oldValue + value);
        }
    }
}