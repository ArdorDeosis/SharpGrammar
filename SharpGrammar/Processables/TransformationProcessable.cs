using System;

namespace SharpGrammar
{
    internal record TransformationProcessable<TFrom, TTo> : Processable<TTo>
    {
        private readonly Processable<TFrom> value;
        private readonly Func<TFrom, IContext, TTo> function;

        internal TransformationProcessable(Processable<TFrom> value, Func<TFrom, IContext, TTo> function)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            this.function = function ?? throw new ArgumentNullException(nameof(function));
        }

        /// <inheritdoc />
        public override TTo Process(IContext context) => function(value.Process(context), context);
    }
}