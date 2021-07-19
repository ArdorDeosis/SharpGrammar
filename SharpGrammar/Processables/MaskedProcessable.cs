using System;

namespace SharpGrammar
{
    internal record MaskedProcessable<T> : Processable<T>
    {
        private readonly Processable action;

        internal MaskedProcessable(Processable action) =>
            this.action = action ?? throw new ArgumentNullException(nameof(action));

        public static implicit operator Processable(MaskedProcessable<T> maskedProcessable) => maskedProcessable.action;
        
        public static implicit operator MaskedProcessable<T>(Processable processable) => new(processable);

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            action.Process(context);
            return context.GetNullValue<T>();
        }
    }
}