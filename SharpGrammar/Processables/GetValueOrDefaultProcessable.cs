using System;

namespace SharpGrammar
{
    internal class GetValueOrDefaultProcessable : Processable
    {
        private readonly string name;
        private readonly Processable defaultValue;
        internal GetValueOrDefaultProcessable(string name, Processable defaultValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.defaultValue = defaultValue  ?? throw new ArgumentNullException(nameof(defaultValue));
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            return context.Get<IMemoryModule>().TryGetValue(name, out Processable? processable)
                ? processable!.Process(context)
                : defaultValue.Process(context);
        }
    }
}