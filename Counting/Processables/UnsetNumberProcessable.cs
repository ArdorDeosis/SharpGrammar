using System;

namespace SharpGrammar.Counting
{
    internal class UnsetNumberProcessable<T> : Processable<T>
    {
        private readonly string name;
        internal UnsetNumberProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            context.Get<INumberModule<T>>().UnsetNumber(name);
            return context.NullValue;
        }
    }
}