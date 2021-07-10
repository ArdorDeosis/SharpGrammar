using System;

namespace SharpGrammar
{
    internal record ConditionProcessable<T> : Processable<T>
    {
        private readonly Func<IContext<T>, bool> condition;
        private readonly Processable<T> trueValue;
        private readonly Processable<T> falseValue;

        internal ConditionProcessable(Func<IContext<T>, bool> condition, Processable<T> trueValue, Processable<T> falseValue)
        {
            this.condition = condition ?? throw new ArgumentNullException(nameof(condition));
            this.trueValue = trueValue  ?? throw new ArgumentNullException(nameof(trueValue));
            this.falseValue = falseValue ?? throw new ArgumentNullException(nameof(falseValue));
        }

        /// <inheritdoc />
        public override T Process(IContext<T> context) =>
            condition(context)
                ? trueValue.Process(context)
                : falseValue.Process(context);
    }
}