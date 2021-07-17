using System;
using System.Diagnostics.CodeAnalysis;

namespace SharpGrammar
{
    /// <summary>
    /// A <see cref="Processable{T}"/> with a weight attached.
    /// Negative weights are not supported and will lead to exceptions.
    /// </summary>
    public readonly struct WeightedOutcome<T>
    {
        internal readonly int Weight;
        internal readonly Processable<T> Processable;

        private WeightedOutcome(Processable<T> processable, int weight)
        {
            this.Processable = processable;
            this.Weight = weight;
        }

        public static implicit operator WeightedOutcome<T>(T value) =>
            new(new ValueProcessable<T>(value), 1);
        
        public static implicit operator WeightedOutcome<T>(Processable<T> processable) =>
            new(processable, 1);
        
        /// <exception cref="ArgumentException">If the provided <paramref name="tuple.weight"/> is negative.</exception>
        [SuppressMessage("ReSharper", "CA2208")]
        public static implicit operator WeightedOutcome<T>((int weight, Processable<T> processable) tuple)
        {
            if (tuple.weight < 0)
                throw new ArgumentException("Negative weights are not supported.", nameof(tuple.weight));
            return new WeightedOutcome<T>(tuple.processable, tuple.weight);
        }
    }
}