using System;

namespace SharpGrammar
{
    /// <summary>
    /// A <see cref="Processable"/> with a weight attached.
    /// Negative weights are not supported and will lead to exceptions.
    /// </summary>
    public readonly struct WeightedOutcome
    {
        internal readonly int weight;
        internal readonly Processable processable;

        private WeightedOutcome(Processable processable, int weight)
        {
            this.processable = processable;
            this.weight = weight;
        }

        public static implicit operator WeightedOutcome(string value) =>
            new(new ValueProcessable(value), 1);
        
        public static implicit operator WeightedOutcome(Processable processable) =>
            new(processable, 1);
        
        /// <exception cref="ArgumentException">If the provided <paramref name="tuple.weight"/> is negative.</exception>
        public static implicit operator WeightedOutcome((int weight, Processable processable) tuple)
        {
            if (tuple.weight < 0)
                throw new ArgumentException("Negative weights are not supported.", nameof(tuple.weight));
            return new WeightedOutcome(tuple.processable, tuple.weight);
        }
    }
}