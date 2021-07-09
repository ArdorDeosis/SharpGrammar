using System;

namespace SharpGrammar
{
    internal class ActionProcessable<T> : Processable<T>
    {
        private readonly Action<IContext<T>> action;

        internal ActionProcessable(Action<IContext<T>> action) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            action.Invoke(context);
            return context.NullValue;
        }
    }
}