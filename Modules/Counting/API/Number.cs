using System;

namespace SharpGrammar.Counting
{
    public static class Number
    {

        /// <summary>
        /// Sets the number named <paramref name="name"/> to <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to set the number to.</param>
        /// <param name="override">Whether an existing number should be overridden.</param>
        public static Processable Set(string name, int value, bool @override = true) =>
            new SetNumberProcessable(name, value, @override);

        /// <summary>
        /// Sets the number named <paramref name="name"/> to a  value between (incl.) <paramref name="minValue"/> and
        /// (incl.) <paramref name="maxValue"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="minValue">Minimum value of the resulting number.</param>
        /// <param name="maxValue">Maximum value of the resulting number (incl.).</param>
        /// <param name="override">Whether an existing number should be overridden.</param>
        public static Processable SetRandom(string name, int minValue, int maxValue, bool @override = true) =>
            new SetRandomNumberProcessable(name, minValue, maxValue, @override);

        /// <summary>
        /// Unsets the number named <paramref name="name"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        public static Processable Unset(string name) => new UnsetNumberProcessable(name);
        
        /// <summary>
        /// Increments the number named <paramref name="name"/> by <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to increment the number by.</param>
        public static Processable Increment(string name, int value = 1) =>
            new IncrementNumberProcessable(name, value);
        
        /// <summary>
        /// Decrements the number named <paramref name="name"/> by <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to decrement the number by.</param>
        public static Processable Decrement(string name, int value = 1) =>
            new IncrementNumberProcessable(name, -value);
        
        /// <summary>
        /// Produces the number named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        public static Processable<int> Get(string name) => new GetNumberProcessable(name);
        
        /// <summary>
        /// Produces the number named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="defaultValue">Number to return if no number named <paramref name="name"/> exists.</param>
        public static Processable<int> GetOrDefault(string name, int defaultValue) =>
            new GetNumberOrDefaultProcessable(name, defaultValue);
    }
}