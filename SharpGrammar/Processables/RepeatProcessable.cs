using System;

namespace SharpGrammar
{
    internal class RepeatProcessable : Processable
    {
        private readonly Processable value;
        private readonly int n;
        private readonly bool preprocess;

        internal RepeatProcessable(Processable value, int n, bool preprocess = false)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            if (n < 0)
                throw new ArgumentOutOfRangeException($"{nameof(n)} has to be >= 0.");
            this.n = n;
            this.preprocess = preprocess;
        }

        /// <inheritdoc />
        public override string Process(IContext context)
        {
            var ruleArray = new Processable[n];
            Array.Fill(ruleArray, preprocess ? new ValueProcessable(value.Process(context)) : value);
            return new ProcessableList(ruleArray).Process(context);
        }
    }
}