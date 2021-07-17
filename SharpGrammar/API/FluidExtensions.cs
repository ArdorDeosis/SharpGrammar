using System;

namespace SharpGrammar
{
    /// <summary>
    /// Extension methods for a fluid usage of <see cref="SharpGrammar" />.
    /// </summary>
    public static class FluidExtensions
    {
        /// <summary>
        /// Processes the provided <see cref="Processable{T}"/> and transforms the produced result with
        /// <paramref name="transform"/>.
        /// </summary>
        /// <param name="value">The value to transform.</param>
        /// <param name="transform">The transformation to execute.</param>
        public static Processable<T> Transform<T>(this Processable<T> value, Func<T, IContext, T> transform) =>
            new TransformationProcessable<T, T>(value, transform);
        
        /// <summary>
        /// Processes the provided <see cref="Processable{T}"/> and transforms the produced result with
        /// <paramref name="transform"/>.
        /// </summary>
        /// <param name="value">The value to transform.</param>
        /// <param name="transform">The transformation to execute.</param>
        public static Processable<TTo> Transform<TFrom, TTo>(this Processable<TFrom> value, Func<TFrom, IContext, TTo> transform) =>
            new TransformationProcessable<TFrom, TTo>(value, transform);

        /// <summary>
        /// Repeats the provided <see cref="Processable{T}"/> <paramref name="n"/> times.
        /// If <paramref name="preprocess"/> == true, the processable is processed once before it is repeated.
        /// </summary>
        /// <param name="processable">The processable to repeat.</param>
        /// <param name="n">How often the processable is repeated.</param>
        /// <param name="preprocess">Whether the processable is processed before it is repeated.</param>
        public static Processable<T> Repeat<T>(this Processable<T> processable, int n, bool preprocess = false) =>
            new RepeatProcessable<T>(processable, n, n, preprocess);

        /// <summary>
        /// Repeats the provided <see cref="Processable{T}"/> between <paramref name="min"/> and (incl.)
        /// <paramref name="max"/> times.
        /// If <paramref name="preprocess"/> == true, the processable is processed once before it is repeated.
        /// </summary>
        /// <param name="processable">The processable to repeat.</param>
        /// <param name="min">Minimum repeats.</param>
        /// <param name="max">Maximum repeats</param>
        /// <param name="preprocess">Whether the processable is processed before it is repeated.</param>
        public static Processable<T> Repeat<T>(this Processable<T> processable, int min, int max, bool preprocess = false) =>
            new RepeatProcessable<T>(processable, min, max, preprocess);

        /// <summary>
        /// Repeats the provided value <paramref name="n"/> times.
        /// If <paramref name="preprocess"/> == true, the processable is processed once before it is repeated.
        /// </summary>
        /// <param name="value">The processable to repeat.</param>
        /// <param name="n">How often the processable is repeated.</param>
        /// <param name="preprocess">Whether the processable is processed before it is repeated.</param>
        public static Processable<T> Repeat<T>(this T value, int n, bool preprocess = false) =>
            new RepeatProcessable<T>(new ValueProcessable<T>(value), n, n, preprocess);

        /// <summary>
        /// Repeats the provided value between <paramref name="min"/> and (incl.)
        /// <paramref name="max"/> times.
        /// If <paramref name="preprocess"/> == true, the processable is processed once before it is repeated.
        /// </summary>
        /// <param name="value">The processable to repeat.</param>
        /// <param name="min">Minimum repeats.</param>
        /// <param name="max">Maximum repeats</param>
        /// <param name="preprocess">Whether the processable is processed before it is repeated.</param>
        public static Processable<T> Repeat<T>(this T value, int min, int max, bool preprocess = false) =>
            new RepeatProcessable<T>(new ValueProcessable<T>(value), min, max, preprocess);

        /// <summary>
        /// Processes the provided <see cref="Processable{T}"/> if <paramref name="condition"/> is true.
        /// </summary>
        /// <param name="processable">The processable to be processed.</param>
        /// <param name="condition">The condition to be checked.</param>
        public static ConditionProcessableInfo<T> If<T>(this Processable<T> processable, Func<IContext, bool> condition) =>
            new(processable, condition);
    }
}