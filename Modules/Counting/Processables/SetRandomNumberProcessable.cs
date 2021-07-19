using System;

namespace SharpGrammar.Counting
{
    internal record SetRandomNumberProcessable : Processable
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
        public override void Process(IContext context)
        {
            var n = minValue + context.GetRandomInt(maxValue - minValue + 1);
            context.Get<INumberModule>().SetNumber(name, n, overrideExistingValue);
        }
    }
}