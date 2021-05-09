using System;

namespace SharpGrammar
{
    internal class TransformationProcessable : Processable
    {
        private readonly Processable value;
        private readonly Func<string, IContext, string> function;

        internal TransformationProcessable(Processable value, Func<string, IContext, string> function)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            this.function = function?? throw new ArgumentNullException(nameof(function));
        }

        /// <inheritdoc />
        public override string Process(IContext context) => function(value.Process(context), context);
    }
}