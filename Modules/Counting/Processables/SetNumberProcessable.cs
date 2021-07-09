using System;

namespace SharpGrammar.Counting
{
    internal class SetNumberProcessable<T> : Processable<T>
    {
        private readonly string name;
        private readonly int value;
        private readonly bool overrideExistingValue;
        
        internal SetNumberProcessable(string name, int value, bool overrideExistingValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.value = value;
            this.overrideExistingValue = overrideExistingValue;
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            context.Get<INumberModule<T>>().SetNumber(name, value, overrideExistingValue);
            return context.NullValue;
        }
    }
}