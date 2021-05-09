using System;

namespace SharpGrammar
{
    internal class ActionProcessable : Processable
    {
        private readonly Action<IContext> action;

        internal ActionProcessable(Action<IContext> action) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            action.Invoke(context);
            return context.NullValue;
        }
    }
}