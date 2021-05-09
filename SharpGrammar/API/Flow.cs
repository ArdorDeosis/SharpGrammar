using System;

namespace SharpGrammar.API
{
    public static class Flow
    {
        /// <summary>
        /// Repeats the provided <see cref="Processable"/> <paramref name="n"/> times.
        /// If <paramref name="preprocess"/> == true, the processable is processed once before it is repeated.
        /// </summary>
        /// <param name="processable">The processable to repeat.</param>
        /// <param name="n">How often the processable is repeated.</param>
        /// <param name="preprocess">Whether the processable is processed before it is repeated.</param>
        public static Processable Repeat(this Processable processable, int n, bool preprocess = false) =>
            new RepeatProcessable(processable, n, preprocess);

        /// <summary>
        /// Processes <paramref name="trueValue"/> if <paramref name="condition"/> is true, otherwise produces no value.
        /// </summary>
        public static Processable If(Func<IContext, bool> condition, Processable trueValue) =>
            If(condition, trueValue, Rule.Nothing);
        
        /// <summary>
        /// Processes <paramref name="trueValue"/> if <paramref name="condition"/> is true,
        /// otherwise processes <paramref name="falseValue"/>.
        /// </summary>
        public static Processable If(Func<IContext, bool> condition, Processable trueValue, Processable falseValue) =>
            new ConditionProcessable(condition, trueValue, falseValue);
    }
}