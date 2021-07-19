using System;

namespace SharpGrammar
{
    internal record RepeatProcessable<T> : Processable<T>
    {
        private readonly Processable<T> value;
        private readonly Processable<int> count;
        private readonly bool preprocess;

        internal RepeatProcessable(Processable<T> value, Processable<int> count, bool preprocess = false)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            this.count = count ?? throw new ArgumentNullException(nameof(count));
            this.preprocess = preprocess;
        }

        /// <inheritdoc />
        public override T Process(IContext context)
        {
            var ruleArray = new Processable<T>[count.Process(context)];
            Array.Fill(ruleArray, preprocess ? new ValueProcessable<T>(value.Process(context)) : value);
            return new ProcessableList<T>(ruleArray).Process(context);
        }
    }
}