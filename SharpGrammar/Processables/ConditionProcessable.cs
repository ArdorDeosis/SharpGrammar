using System;

namespace SharpGrammar
{
    internal class ConditionProcessable : Processable
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
        public override string Process(IContext context) =>
            condition(context)
                ? trueValue.Process(context)
                : falseValue.Process(context);
    }
}