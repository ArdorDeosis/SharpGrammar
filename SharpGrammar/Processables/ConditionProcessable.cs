using System;

namespace SharpGrammar
{
    internal record ConditionProcessable : Processable
    {
        private readonly Func<IContext, bool> condition;
        private readonly Processable trueValue;
        private readonly Processable falseValue;

        internal ConditionProcessable(Func<IContext, bool> condition, Processable trueValue, Processable falseValue)
        {
            this.condition = condition ?? throw new ArgumentNullException(nameof(condition));
            this.trueValue = trueValue  ?? throw new ArgumentNullException(nameof(trueValue));
            this.falseValue = falseValue ?? throw new ArgumentNullException(nameof(falseValue));
        }

        /// <inheritdoc />
        public override void Process(IContext context)
        {
            if (condition(context))
                trueValue.Process(context);
            else
                falseValue.Process(context);
        }
    }
    
    internal record ConditionProcessable<T> : Processable<T>
    {
        private readonly Func<IContext, bool> condition;
        private readonly Processable<T> trueValue;
        private readonly Processable<T> falseValue;

        internal ConditionProcessable(Func<IContext, bool> condition, Processable<T> trueValue, Processable<T> falseValue)
        {
            this.condition = condition ?? throw new ArgumentNullException(nameof(condition));
            this.trueValue = trueValue  ?? throw new ArgumentNullException(nameof(trueValue));
            this.falseValue = falseValue ?? throw new ArgumentNullException(nameof(falseValue));
        }

        /// <inheritdoc />
        public override T Process(IContext context) =>
            condition(context)
                ? trueValue.Process(context)
                : falseValue.Process(context);
    }
}