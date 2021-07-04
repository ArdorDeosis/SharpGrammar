namespace SharpGrammar.Memory
{
    public static class Memory
    {
        /// <summary>
        /// Sets the variable named <paramref name="name"/> to <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="value">Value of the variable.</param>
        /// <param name="preprocess">Whether the value should be preprocessed.</param>
        /// <param name="override">Whether an existing value should be overridden.</param>
        public static Processable<T> Set<T>(string name, Processable<T> value, bool preprocess = true, bool @override = true) =>
            new SetValueProcessable<T>(name, value, preprocess, @override);

        /// <summary>
        /// Unsets the variable named <paramref name="name"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the variable to unset.</param>
        public static Processable<T> Unset<T>(string name) => new UnsetValueProcessable<T>(name);

        /// <summary>
        /// Produces the value of the variable named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        public static Processable<T> Get<T>(string name) => new GetValueProcessable<T>(name);

        /// <summary>
        /// Produces the value of the variable named <paramref name="name"/>
        /// or processes <paramref name="defaultValue"/> if no variable with that name exists.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="defaultValue"><see cref="Processable{T}"/> to process if no variable named <paramref name="name"/> is
        /// not set.</param>
        public static Processable<T> TryGet<T>(string name, Processable<T> defaultValue) =>
            new GetValueOrDefaultProcessable<T>(name, defaultValue);
    }
}