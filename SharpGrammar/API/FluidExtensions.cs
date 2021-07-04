using System;

namespace SharpGrammar
{
    /// <summary>
    /// Extension methods for a fluid usage of <see cref="SharpGrammar" />.
    /// </summary>
    public static class FluidExtensions
    {
        /// <summary>
        /// Processes the <see cref="Processable"/> with a newly created <see cref="IContext"/>.
        /// </summary>
        public static string Process(this Processable processable) => processable.Process(new Context());

        /// <summary>
        /// Processes the provided <see cref="Processable"/> and transforms the produced result with
        /// <paramref name="transform"/>.
        /// </summary>
        /// <param name="value">The value to transform.</param>
        /// <param name="transform">The transformation to execute.</param>
        public static Processable Transform(this Processable value, Func<string, IContext, string> transform) =>
            new TransformationProcessable(value, transform);

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
        /// Processes the provided <see cref="Processable"/> if <paramref name="condition"/> is true.
        /// </summary>
        /// <param name="processable">The processable to be processed.</param>
        /// <param name="condition">The condition to be checked.</param>
        public static ConditionProcessableInfo If(this Processable processable, Func<IContext, bool> condition) =>
            new(processable, condition);
    }
}