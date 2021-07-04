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
        public static Processable Over(IteratorRandomization randomization, params Processable[] values) =>
            new IteratorProcessable(values, randomization);

        /// <inheritdoc cref="Over(SharpGrammar.Iteration.IteratorRandomization,SharpGrammar.Processable[])"/>
        public static Processable Over(params Processable[] values) => new IteratorProcessable(values);

        /// <inheritdoc cref="Over(SharpGrammar.Processable[])"/>
        public static Processable Over(IEnumerable<Processable> values) => Over(values.ToArray());
    }
}