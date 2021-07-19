using System;
using System.Collections.Generic;

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
        /// Processes the provided <see cref="Processable{T}"/> and transforms the produced result with
        /// <paramref name="transform"/>.
        /// </summary>
        /// <param name="value">The value to transform.</param>
        /// <param name="transform">The transformation to execute.</param>
        public static Processable<TTo> Convert<TFrom, TTo>(this Processable<TFrom> value, Func<TFrom, TTo> convert) =>
            new TransformationProcessable<TFrom, TTo>(value, (value, context) => convert(value));

        /// <summary>
        /// Repeats the provided <see cref="Processable{T}"/> <paramref name="count"/> times.
        /// If <paramref name="preprocess"/> == true, the processable is processed once before it is repeated.
        /// </summary>
        /// <param name="processable">The processable to repeat.</param>
        /// <param name="count">How often the processable is repeated.</param>
        /// <param name="preprocess">Whether the processable is processed before it is repeated.</param>
        public static Processable<T> Repeat<T>(this Processable<T> processable, Processable<int> count, bool preprocess = false) =>
            new RepeatProcessable<T>(processable, count, preprocess);

        /// <summary>
        /// Repeats the provided value <paramref name="count"/> times.
        /// If <paramref name="preprocess"/> == true, the processable is processed once before it is repeated.
        /// </summary>
        /// <param name="value">The processable to repeat.</param>
        /// <param name="count">How often the processable is repeated.</param>
        /// <param name="preprocess">Whether the processable is processed before it is repeated.</param>
        public static Processable<T> Repeat<T>(this T value, int count, bool preprocess = false) =>
            new RepeatProcessable<T>(new ValueProcessable<T>(value), count, preprocess);

        /// <summary>
        /// Processes the provided <see cref="Processable"/> if <paramref name="condition"/> is true.
        /// </summary>
        /// <param name="processable">The processable to be processed.</param>
        /// <param name="condition">The condition to be checked.</param>
        public static ConditionProcessableInfo If(this Processable processable, Func<IContext, bool> condition) =>
            new(processable, condition);
        
        /// <summary>
        /// Processes the provided <see cref="Processable{T}"/> if <paramref name="condition"/> is true.
        /// </summary>
        /// <param name="processable">The processable to be processed.</param>
        /// <param name="condition">The condition to be checked.</param>
        public static ConditionProcessableInfo<T> If<T>(this Processable<T> processable, Func<IContext, bool> condition) =>
            new(processable, condition);

        /// <inheritdoc cref="If(SharpGrammar.Processable,System.Func{SharpGrammar.IContext,bool})"/>
        public static ConditionProcessableInfo If(this Processable processable, Func<bool> condition) =>
            new(processable, _ => condition());
        
        /// <inheritdoc cref="If{T}(SharpGrammar.Processable{T},System.Func{SharpGrammar.IContext,bool})"/>
        public static ConditionProcessableInfo<T> If<T>(this Processable<T> processable, Func<bool> condition) =>
            new(processable, _ => condition());

        /// <summary>
        /// TODO
        /// </summary>
        public static SwitchCaseProcessableInfo<TIn> Switch<TIn>(this Processable<TIn> processable)
            where TIn : notnull => new(processable);
        
        /// <summary>
        /// TODO
        /// </summary>
        public static SwitchCaseProcessableInfo<TIn, TOut> Switch<TIn, TOut>(this Processable<TIn> processable)
            where TIn : notnull => new(processable);
        
        /// <summary>
        /// Assigns a weight to the processable to be used in <see cref="Take.OneOf{T}(WeightedOutcome{T}[])"/> or
        /// <see cref="Take.OneOf{T}(IEnumerable{WeightedOutcome{T}})"/>.
        /// </summary>
        /// <param name="processable">The processable the weight is assigned to.</param>
        /// <param name="weight">The weight to be assigned to this processable. Must be >= 0.</param>
        public static WeightedOutcome<T> WithWeight<T>(this Processable<T> processable, int weight) =>
            new(processable, weight);
        
        /// <summary>
        /// Assigns a weight to the processable to be used in <see cref="Take.OneOf{T}(WeightedOutcome{T}[])"/> or
        /// <see cref="Take.OneOf{T}(IEnumerable{WeightedOutcome{T}})"/>.
        /// </summary>
        /// <param name="processable">The processable the weight is assigned to.</param>
        /// <param name="weight">The weight to be assigned to this processable. Must be >= 0.</param>
        public static WeightedOutcome<T> WithWeight<T>(this T value, int weight) =>
            new(value, weight);
    }
}