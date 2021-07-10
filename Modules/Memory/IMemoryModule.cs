namespace SharpGrammar.Memory
{
    /// <summary>
    /// A module providing simple memory functionality.
    /// </summary>
    public interface IMemoryModule<T>
    {
        /// <summary>
        /// Saves the provided <paramref name="value"/> to context-memory with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value of the variable.</param>
        /// <param name="override">Whether the variable should be overridden, if one with the same name already
        /// exists.</param>
        void SetValue(string name, Processable<T> value, bool @override = true);

        /// <summary>
        /// Unsets the variable with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the variable to unset.</param>
        void UnsetValue(string name);

        /// <summary>
        /// Returns the variable named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the variable to return.</param>
        Processable<T> GetValue(string name);

        /// <summary>
        /// Retrieves the variable named <paramref name="name"/>, if it exists.
        /// </summary>
        /// <param name="name">The name of the variable to return.</param>
        /// <param name="value">Contains the value of the variable if found, null otherwise.</param>
        /// <returns>Whether the variable was found or not.</returns>
        bool TryGetValue(string name, out Processable<T>? value);
    }
}