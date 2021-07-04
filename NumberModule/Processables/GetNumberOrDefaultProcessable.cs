using System;

namespace SharpGrammar.NumberModule
{
    internal class GetNumberOrDefaultProcessable : Processable
    {
        private readonly string name;
        private readonly int defaultValue; 
        internal GetNumberOrDefaultProcessable(string name, int defaultValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.defaultValue = defaultValue;
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            return context.Get<INumberModule>().TryGetNumber(name, out int value)
                ? value.ToString()
                : defaultValue.ToString();
        }
    }
}