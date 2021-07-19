using System;

namespace SharpGrammar.Counting
{
    internal record SetNumberProcessable : Processable
    {
        private readonly string name;
        private readonly Processable<int> value;
        private readonly bool overrideExistingValue;
        
        internal SetNumberProcessable(string name, Processable<int> value, bool overrideExistingValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.value = value;
            this.overrideExistingValue = overrideExistingValue;
        }

        /// <inheritdoc />
        public override void Process(IContext context) =>
            context.Get<INumberModule>().SetNumber(name, value.Process(context), overrideExistingValue);
    }
}