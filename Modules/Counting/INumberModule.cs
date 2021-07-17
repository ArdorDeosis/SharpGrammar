namespace SharpGrammar.Counting
{
    /// <summary>
    /// A module providing simple counting functionality.
    /// </summary>
    public interface INumberModule<out T>
    {
        /// <summary>
        /// Converts an integer value to the return type.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        T Convert(int value);
        
        /// <summary>
        /// Saves the provided <paramref name="value"/> to context-memory with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the number.</param>
        /// <param name="value">The value of the number.</param>
        /// <param name="override">Whether the number should be overridden, if one with the same name already
        /// exists.</param>
        void SetNumber(string name, int value, bool @override = true);

        /// <summary>
        /// Unsets the number with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the number to unset.</param>
        void UnsetNumber(string name);

        /// <summary>
        /// Returns the number named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the number to return.</param>
        int GetNumber(string name);

        
        /// <summary>
        /// Retrieves and converts the number named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the number to return and convert.</param>
        T GetAndConvert(string name) => Convert(GetNumber(name));

        /// <summary>
        /// Retrieves the number named <paramref name="name"/>, if it exists.
        /// </summary>
        /// <param name="name">The name of the number to return.</param>
        /// <param name="value">Contains the value of the number if found, null otherwise.</param>
        /// <returns>Whether the number was found or not.</returns>
        bool TryGetNumber(string name, out int value);
    }
}