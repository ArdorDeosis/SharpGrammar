using System;
using System.Diagnostics.CodeAnalysis;

namespace SharpGrammar
{
    public class ConditionProcessableInfo
    {
        private readonly Processable processable;
        private readonly Func<IContext, bool> condition;
        private Processable elseCase = Take.Nothing;

        public ConditionProcessableInfo(Processable processable, Func<IContext, bool> condition)
        {
            this.processable = processable;
            this.condition = condition;
        }
        
        public static implicit operator Processable(ConditionProcessableInfo info) =>
            new ConditionProcessable(info.condition, info.processable, info.elseCase);

        [SuppressMessage("ReSharper", "ParameterHidesMember")]
        public Processable Else(Processable processable)
        {
            elseCase = processable;
            return this;
        }
    }
}