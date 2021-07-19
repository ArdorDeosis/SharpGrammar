using System.Collections.Generic;
using System.Linq;

namespace SharpGrammar
{
    public class SwitchCaseProcessableInfo<TIn> where TIn : notnull
    {
        private readonly Processable<TIn> conditionProcessable;
        private readonly Dictionary<TIn, Processable> cases = new();
        private Processable? defaultCase;

        internal SwitchCaseProcessableInfo(Processable<TIn> conditionProcessable)
        {
            this.conditionProcessable = conditionProcessable;
        }

        public static implicit operator Processable(SwitchCaseProcessableInfo<TIn> info) =>
            new SwitchCaseProcessable<TIn>(info.conditionProcessable, info.cases, info.defaultCase);

        public SwitchCaseProcessableInfo<TIn> Case(TIn value, Processable processable)
        {
            cases.Add(value, processable);
            return this;
        }

        public SwitchCaseProcessableInfo<TIn> Default(Processable processable)
        {
            defaultCase = processable;
            return this;
        }

        public SwitchCaseProcessableInfo<TIn, TOut> Case<TOut>(TIn value, Processable<TOut> processable) =>
            ToValueOutput<TOut>().Case(value, processable);

        public SwitchCaseProcessableInfo<TIn, TOut> Default<TOut>(Processable<TOut> processable) =>
            ToValueOutput<TOut>().Default(processable);


        private SwitchCaseProcessableInfo<TIn, TOut> ToValueOutput<TOut>()
        {
            var convertedCases = cases.ToDictionary(
                keyValuePair => keyValuePair.Key,
                keyValuePair => keyValuePair.Value.AsProcessable<TOut>());
            return new SwitchCaseProcessableInfo<TIn, TOut>(conditionProcessable, convertedCases, 
                defaultCase?.AsProcessable<TOut>());
        }
    }

    public class SwitchCaseProcessableInfo<TIn, TOut> where TIn : notnull
    {
        private readonly Processable<TIn> conditionProcessable;
        private readonly Dictionary<TIn, Processable<TOut>> cases = new();
        private Processable<TOut>? defaultCase;

        internal SwitchCaseProcessableInfo(Processable<TIn> conditionProcessable)
        {
            this.conditionProcessable = conditionProcessable;
        }

        internal SwitchCaseProcessableInfo(Processable<TIn> conditionProcessable,
            Dictionary<TIn, Processable<TOut>> cases, Processable<TOut>? defaultCase)
        {
            this.conditionProcessable = conditionProcessable;
            this.defaultCase = defaultCase;
            this.cases = cases;
        }

        public static implicit operator Processable<TOut>(SwitchCaseProcessableInfo<TIn, TOut> info) =>
            new SwitchCaseProcessable<TIn, TOut>(info.conditionProcessable, info.cases, info.defaultCase);

        public SwitchCaseProcessableInfo<TIn, TOut> Case(TIn value, Processable<TOut> processable)
        {
            cases.Add(value, processable);
            return this;
        }

        public SwitchCaseProcessableInfo<TIn, TOut> Default(Processable<TOut> processable)
        {
            defaultCase = processable;
            return this;
        }
    }
}