using System.Collections.Generic;
using System.Linq;

namespace SharpGrammar
{
    public static class Take
    {
        /// <summary>
        /// A <see cref="NullProcessable{T}"/> that does and produces nothing.
        /// </summary>
        public static Processable<T> Nothing<T>() => new NullProcessable<T>();

        /// <summary>
        /// A <see cref="Processable{T}"/> that always produces <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to produce.</param>
        public static Processable<T> Value<T>(T value) => new ValueProcessable<T>(value);

        /// <summary>
        /// Produces one randomly chosen value of <paramref name="values"/>. 
        /// </summary>
        /// <param name="values">The values to choose from.</param>
        /// <returns></returns>
        public static Processable<T> OneOf<T>(params WeightedOutcome<T>[] values) => new OneOfProcessable<T>(values);

        /// <inheritdoc cref="OneOf{T}(SharpGrammar.WeightedOutcome{T}[])"/>
        public static Processable<T> OneOf<T>(IEnumerable<WeightedOutcome<T>> values) => OneOf(values.ToArray());
    }
}