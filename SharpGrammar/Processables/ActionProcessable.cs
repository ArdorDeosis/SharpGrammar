using System;

namespace SharpGrammar
{
    internal record ActionProcessable<T> : Processable<T>
    {
        private readonly Action<IContext> action;

        internal ActionProcessable(Action<IContext> action) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            action.Invoke(context);
            return context.GetNullValue<T>();
        }
    }
}