using System;

namespace SharpGrammar
{
    internal record ActionProcessable : Processable
    {
        private readonly Action<IContext> action;

        internal ActionProcessable(Action<IContext> action) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        public static implicit operator ActionProcessable(Action<IContext> action) => new(action);

        /// <inheritdoc />
        public override void Process(IContext context) => action.Invoke(context);
    }
}