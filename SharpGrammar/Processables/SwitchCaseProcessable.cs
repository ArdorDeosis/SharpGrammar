using System.Collections.Generic;

namespace SharpGrammar
{
    public record SwitchCaseProcessable<TIn> : Processable where TIn : notnull
    {
        private readonly Processable<TIn> conditionProcessable;
        private readonly Dictionary<TIn, Processable> cases;
        private readonly Processable? defaultCase;
        
        internal SwitchCaseProcessable(Processable<TIn> conditionProcessable, Dictionary<TIn, Processable> cases,
            Processable? defaultCase = null)
        {
            this.conditionProcessable = conditionProcessable;
            this.cases = cases;
            this.defaultCase = defaultCase;
        }

        public override void Process(IContext context)
        {
        var conditionValue = conditionProcessable.Process(context);
            foreach (var (key, processable) in cases)
            {
                if (key.Equals(conditionValue))
                {
                    processable.Process(context);
                    return;
                }
            }
            defaultCase?.Process(context); 
        }
    }
    
    public record SwitchCaseProcessable<TIn, TOut> : Processable<TOut> where TIn : notnull
    {
        private readonly Processable<TIn> conditionProcessable;
        private readonly Dictionary<TIn, Processable<TOut>> cases;
        private readonly Processable<TOut>? defaultCase;
        
        internal SwitchCaseProcessable(Processable<TIn> conditionProcessable, Dictionary<TIn, Processable<TOut>> cases,
            Processable<TOut>? defaultCase = null)
        {
            this.conditionProcessable = conditionProcessable;
            this.cases = cases;
            this.defaultCase = defaultCase;
        }

        public override TOut Process(IContext context)
        {
        var conditionValue = conditionProcessable.Process(context);
            foreach (var (key, processable) in cases)
            {
                if (key.Equals(conditionValue))
                    return processable.Process(context);
            }
            return defaultCase != null 
                ? defaultCase.Process(context) 
                : context.GetNullValue<TOut>();
        }
    }
}