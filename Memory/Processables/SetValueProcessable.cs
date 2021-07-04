using System;

namespace SharpGrammar.Memory.Processables
{
    internal class SetValueProcessable : Processable
    {
        private readonly string name;
        private readonly Processable value;
        private readonly bool preprocess;
        private readonly bool overrideExistingValue;
        
        internal SetValueProcessable(string name, Processable value, bool preprocess, bool overrideExistingValue)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
            this.value = value ?? throw new ArgumentNullException(nameof(value));;
            this.preprocess = preprocess;
            this.overrideExistingValue = overrideExistingValue;
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            context.Get<IMemoryModule>().SetValue(name, preprocess ? value.Process(context) : value, overrideExistingValue);
            return context.NullValue;
        }
    }
}