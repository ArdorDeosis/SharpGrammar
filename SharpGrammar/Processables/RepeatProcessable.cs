using System;

namespace SharpGrammar
{
    internal record RepeatProcessable<T> : Processable<T>
    {
        private readonly Processable<T> value;
        private readonly int min;
        private readonly int max;
        private readonly bool preprocess;

        internal RepeatProcessable(Processable<T> value, int min, int max, bool preprocess = false)
        {
            this.value = value ?? throw new ArgumentNullException(nameof(value));
            this.min = min;
            this.max = max;
            if (min < 0)
                throw new ArgumentOutOfRangeException($"{nameof(min)} has to be >= 0.");
            if (max < 0)
                throw new ArgumentOutOfRangeException($"{nameof(max)} has to be >= 0.");
            if (max < min)
                throw new ArgumentOutOfRangeException($"{nameof(max)} has to be >= {nameof(min)}.");
            this.min = min;
            this.max = max;
            this.preprocess = preprocess;
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context)
        {
            var n = min + context.GetRandomInt(max - min + 1);
            var ruleArray = new Processable<T>[n];
            Array.Fill(ruleArray, preprocess ? new ValueProcessable<T>(value.Process(context)) : value);
            return new ProcessableList<T>(ruleArray).Process(context);
        }
    }
}