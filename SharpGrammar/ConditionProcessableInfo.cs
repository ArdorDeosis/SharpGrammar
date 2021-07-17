using System;
using System.Diagnostics.CodeAnalysis;

namespace SharpGrammar
{
    public class ConditionProcessableInfo<T>
    {
        private readonly Processable<T> processable;
        private readonly Func<IContext, bool> condition;
        private Processable<T> elseCase = Take.Nothing<T>();

        public ConditionProcessableInfo(Processable<T> processable, Func<IContext, bool> condition)
        {
            this.processable = processable;
            this.condition = condition;
        }
        
        public static implicit operator Processable<T>(ConditionProcessableInfo<T> info) =>
            new ConditionProcessable<T>(info.condition, info.processable, info.elseCase);

        [SuppressMessage("ReSharper", "ParameterHidesMember")]
        public Processable<T> Else(Processable<T> processable)
        {
            elseCase = processable;
            return this;
        }
    }
}