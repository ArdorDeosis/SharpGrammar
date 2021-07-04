using System;

namespace SharpGrammar
{
    internal class RepeatProcessable<T> : Processable<T>
    {
        private readonly Processable<T> value;
        private readonly int n;
        private readonly bool preprocess;

        internal RepeatProcessable(Processable<T> value, int n, bool preprocess = false)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            if (n < 0)
                throw new ArgumentOutOfRangeException($"{nameof(n)} has to be >= 0.");
            this.n = n;
            this.preprocess = preprocess;
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            var ruleArray = new Processable<T>[n];
            Array.Fill(ruleArray, preprocess ? new ValueProcessable<T>(value.Process(context)) : value);
            return new ProcessableList<T>(ruleArray).Process(context);
        }
    }
}