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
        public static Processable<T> Set<T>(string name, int value, bool @override = true) =>
            new SetNumberProcessable<T>(name, value, @override);

        /// <summary>
        /// Unsets the number named <paramref name="name"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        public static Processable<T> Unset<T>(string name) => new UnsetNumberProcessable<T>(name);
        
        /// <summary>
        /// Increments the number named <paramref name="name"/> by <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to increment the number by.</param>
        public static Processable<T> Increment<T>(string name, int value = 1) =>
            new IncrementNumberProcessable<T>(name, value);
        
        /// <summary>
        /// Decrements the number named <paramref name="name"/> by <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to decrement the number by.</param>
        public static Processable<T> Decrement<T>(string name, int value = 1) =>
            new IncrementNumberProcessable<T>(name, -value);
        
        /// <summary>
        /// Produces the number named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        public static Processable<T> Get<T>(string name) => new GetNumberProcessable<T>(name);
        
        /// <summary>
        /// Produces the number named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="defaultValue">Number to return if no number named <paramref name="name"/> exists.</param>
        public static Processable<T> TryGet<T>(string name, int defaultValue) =>
            new GetNumberOrDefaultProcessable<T>(name, defaultValue);
    }
}