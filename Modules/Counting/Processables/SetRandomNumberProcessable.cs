using System;

namespace SharpGrammar.Counting
{
    internal record SetRandomNumberProcessable<T> : Processable<T>
    {
        private readonly string name;
        private readonly int minValue;
        private readonly int maxValue;
        private readonly bool overrideExistingValue;
        
        internal SetRandomNumberProcessable(string name, int minValue, int maxValue, bool overrideExistingValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.overrideExistingValue = overrideExistingValue;
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            var n = minValue + context.GetRandomInt(maxValue - minValue + 1);
            context.Get<INumberModule<T>>().SetNumber(name, n, overrideExistingValue);
            return context.NullValue;
        }
    }
}