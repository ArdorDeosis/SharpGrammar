using System.Collections.Generic;
using System.Linq;

namespace SharpGrammar.Iteration
{
    public static class Iterate
    {
        /// <summary>
        /// Iterates over the <paramref name="values"/> producing one at a time.
        /// </summary>
        /// <param name="randomization">If and how the iteration process is randomized.</param>
        /// <param name="values">The values to produce.</param>
        public static Processable<T> Over<T>(IteratorRandomization randomization, params Processable<T>[] values) =>
            new IteratorProcessable<T>(values, randomization);

        /// <inheritdoc cref="Over{T}(SharpGrammar.Iteration.IteratorRandomization,SharpGrammar.Processable{T}[])"/>
        public static Processable<T> Over<T>(params Processable<T>[] values) => new IteratorProcessable<T>(values);

        /// <inheritdoc cref="Over{T}(SharpGrammar.Processable{T}[])"/>
        public static Processable<T> Over<T>(IEnumerable<Processable<T>> values) => Over(values.ToArray());
    }
}