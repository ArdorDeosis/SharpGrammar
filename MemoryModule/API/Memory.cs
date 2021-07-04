namespace SharpGrammar.MemoryModule
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
        public static Processable Set(string name, Processable value, bool preprocess = true, bool @override = true) =>
            new SetValueProcessable(name, value, preprocess, @override);

        /// <summary>
        /// Unsets the variable named <paramref name="name"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the variable to unset.</param>
        public static Processable Unset(string name) => new UnsetValueProcessable(name);

        /// <summary>
        /// Produces the value of the variable named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        public static Processable Get(string name) => new GetValueProcessable(name);

        /// <summary>
        /// Produces the value of the variable named <paramref name="name"/>
        /// or processes <paramref name="defaultValue"/> if no variable with that name exists.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="defaultValue"><see cref="Processable"/> to process if no variable named <paramref name="name"/> is
        /// not set.</param>
        public static Processable TryGet(string name, Processable defaultValue) =>
            new GetValueOrDefaultProcessable(name, defaultValue);
    }
}