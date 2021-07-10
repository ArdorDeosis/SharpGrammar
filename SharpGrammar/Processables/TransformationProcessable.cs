using System;

namespace SharpGrammar
{
    internal record TransformationProcessable<T> : Processable<T>
    {
        private readonly Processable<T> value;
        private readonly Func<T, IContext<T>, T> function;

        internal TransformationProcessable(Processable<T> value, Func<T, IContext<T>, T> function)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            this.function = function ?? throw new ArgumentNullException(nameof(function));
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context) => function(value.Process(context), context);
    }
}