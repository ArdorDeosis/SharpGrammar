using System.Collections.Generic;
using System.Linq;

namespace SharpGrammar.API
{
    public static class Rule
    {
        /// <summary>
        /// A <see cref="NullProcessable"/> that does and produces nothing.
        /// </summary>
        public static Processable Nothing => new NullProcessable();

        /// <summary>
        /// A <see cref="Processable"/> that always produces <paramref name="value"/>.
        /// </summary>
        /// <param name="value">The value to produce.</param>
        public static Processable Value(string value) => new ValueProcessable(value);
        
        /// <summary>
        /// Produces one randomly chosen value of <paramref name="values"/>. 
        /// </summary>
        /// <param name="values">The values to choose from.</param>
        /// <returns></returns>
        public static Processable OneOf(params WeightedOutcome[] values) => new OneOfProcessable(values);
        
        /// <inheritdoc cref="OneOf(SharpGrammar.WeightedOutcome[])"/>
        public static Processable OneOf(IEnumerable<WeightedOutcome> values) => OneOf(values.ToArray());

        /// <summary>
        /// Iterates over the <paramref name="values"/> producing one at a time.
        /// </summary>
        /// <param name="randomization">If and how the iteration process is randomized.</param>
        /// <param name="values">The values to produce.</param>
        public static Processable Iterate(IteratorRandomization randomization, params Processable[] values) =>
            new IteratorProcessable(values, randomization);
        
        /// <inheritdoc cref="Iterate(SharpGrammar.IteratorRandomization,SharpGrammar.Processable[])"/>
        public static Processable Iterate(params Processable[] values) => new IteratorProcessable(values);

        /// <inheritdoc cref="Iterate(Processable[])"/>
        public static Processable Iterate(IEnumerable<Processable> values) => Iterate(values.ToArray());
    }
}