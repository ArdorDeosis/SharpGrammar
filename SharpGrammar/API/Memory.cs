namespace SharpGrammar.API
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
        public static Processable Set(string name, Processable value, bool preprocess = false) =>
            new SetValueProcessable(name, value, preprocess, true);
        
        /// <summary>
        /// Sets the variable named <paramref name="name"/> to <paramref name="value"/> if it is unset.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the variable.</param>
        /// <param name="value">Value of the variable.</param>
        /// <param name="preprocess">Whether the value should be preprocessed.</param>
        public static Processable SetIfUnset(string name, Processable value, bool preprocess = false) =>
            new SetValueProcessable(name, value, preprocess, false);
        
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

        /// <summary>
        /// Sets the number named <paramref name="name"/> to <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to set the number to.</param>
        public static Processable SetNumber(string name, int value) =>
            new SetNumberProcessable(name, value, true);

        /// <summary>
        /// Sets the number named <paramref name="name"/> to <paramref name="value"/> if it is unset.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to set the number to.</param>
        public static Processable SetNumberIfUnset(string name, int value) =>
            new SetNumberProcessable(name, value, false);

        /// <summary>
        /// Unsets the number named <paramref name="name"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        public static Processable UnsetNumber(string name) => new UnsetNumberProcessable(name);
        
        /// <summary>
        /// Increments the number named <paramref name="name"/> by <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to increment the number by.</param>
        public static Processable IncrementNumber(string name, int value = 1) =>
            new IncrementNumberProcessable(name, value);
        
        /// <summary>
        /// Decrements the number named <paramref name="name"/> by <paramref name="value"/>.
        /// Produces no value.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="value">Value to decrement the number by.</param>
        public static Processable DecrementNumber(string name, int value = 1) =>
            new IncrementNumberProcessable(name, -value);
        
        /// <summary>
        /// Produces the number named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        public static Processable GetNumber(string name) => new GetNumberProcessable(name);
        
        /// <summary>
        /// Produces the number named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">Name of the number.</param>
        /// <param name="defaultValue">Number to return if no number named <paramref name="name"/> exists.</param>
        public static Processable TryGetNumber(string name, int defaultValue) =>
            new GetNumberOrDefaultProcessable(name, defaultValue);
    }
}