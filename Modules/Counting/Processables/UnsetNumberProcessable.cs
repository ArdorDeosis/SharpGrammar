using System;

namespace SharpGrammar.Counting
{
    internal record UnsetNumberProcessable<T> : Processable<T>
    {
        private readonly string name;
        internal UnsetNumberProcessable(string name)
        {
            this.name = name ?? throw new ArgumentNullException(nameof(name));
        }

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            context.Get<INumberModule<T>>().UnsetNumber(name);
            return context.NullValue<T>();
        }
    }
}