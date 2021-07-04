using System;

namespace SharpGrammar.Counting.Processables
{
    internal class UnsetNumberProcessable : Processable
    {
        private readonly string name;
        internal UnsetNumberProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            context.Get<INumberModule>().UnsetNumber(name);
            return context.NullValue;
        }
    }
}