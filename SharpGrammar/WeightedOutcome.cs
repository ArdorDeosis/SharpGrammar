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

        internal WeightedOutcome(Processable<T> processable, int weight)
        {
            Processable = processable ?? throw new ArgumentNullException(nameof(processable));
            if (weight < 0)
                throw new ArgumentException("Negative weights are not supported.", nameof(weight));
            Weight = weight;
        }

        public static implicit operator WeightedOutcome<T>(T value) =>
            new(new ValueProcessable<T>(value), 1);
        
        public static implicit operator WeightedOutcome<T>(Processable<T> processable) =>
            new(processable, 1);
        
        [SuppressMessage("ReSharper", "CA2208")]
        public static implicit operator WeightedOutcome<T>((int weight, Processable<T> processable) tuple) =>
            new(tuple.processable, tuple.weight);
    }
}