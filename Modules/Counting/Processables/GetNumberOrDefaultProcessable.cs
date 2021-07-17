using System;

namespace SharpGrammar.Counting
{
    internal record GetNumberOrDefaultProcessable : Processable<int>
    {
        private readonly string name;
        private readonly int defaultValue; 
        internal GetNumberOrDefaultProcessable(string name, int defaultValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.defaultValue = defaultValue;
        }

        /// <inheritdoc />
        public override int Process(IContext context)
        {
            var numberModule = context.Get<INumberModule>();
            return numberModule.TryGetNumber(name, out var value)
                ? value
                : defaultValue;
        }
    }
}