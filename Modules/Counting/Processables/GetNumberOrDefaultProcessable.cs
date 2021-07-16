using System;

namespace SharpGrammar.Counting
{
    internal record GetNumberOrDefaultProcessable<T> : Processable<T>
    {
        private readonly string name;
        private readonly int defaultValue; 
        internal GetNumberOrDefaultProcessable(string name, int defaultValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.defaultValue = defaultValue;
        }

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            var numberModule = context.Get<INumberModule<T>>();
            return numberModule.TryGetNumber(name, out var value)
                ? numberModule.Convert(value)
                : numberModule.Convert(defaultValue);
        }
    }
}