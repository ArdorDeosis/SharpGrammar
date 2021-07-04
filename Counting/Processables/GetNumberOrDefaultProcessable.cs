using System;

namespace SharpGrammar.Counting
{
    internal class GetNumberOrDefaultProcessable<T> : Processable<T>
    {
        private readonly string name;
        private readonly int defaultValue;

        internal GetNumberOrDefaultProcessable(string name, int defaultValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.defaultValue = defaultValue;
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            var module = context.Get<INumberModule<T>>();
            return module.Convert(
                module.TryGetNumber(name, out var value)
                    ? value
                    : defaultValue
            );
        }
    }
}