using System;
using System.Collections.Generic;

namespace SharpGrammar.Counting
{
    /// <summary>
    /// A module providing simple counting functionality.
    /// </summary>
    public interface INumberModule<T>
    {
        /// <summary>
        /// Saves the provided <paramref name="value"/> to context-memory with the name <paramref name="name"/>.
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
        /// Retrieves the number named <paramref name="name"/>, if it exists.
        /// </summary>
        /// <param name="name">The name of the number to return.</param>
        /// <param name="value">Contains the value of the number if found, null otherwise.</param>
        /// <returns>Whether the number was found or not.</returns>
        bool TryGetNumber(string name, out int value);

        T Convert(int value);
    }

    /// <inheritdoc />
    public class NumberModule<T> : INumberModule<T>
    {
        private readonly Dictionary<string, int> numbers = new();

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public void SetNumber(string name, int value, bool @override = true)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (!numbers.ContainsKey(name))
            {
                numbers.Add(name, value);
                return;
            }

            if (@override)
                numbers[name] = value;
        }

        /// <inheritdoc />
        public void UnsetNumber(string name) => numbers.Remove(name);

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">No number named '<paramref name="name"/>' exists.
        /// </exception>
        public int GetNumber(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (!numbers.ContainsKey(name))
                throw new ArgumentOutOfRangeException($"Number '{name}' does not exist in this context.");
            return numbers[name];
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public bool TryGetNumber(string name, out int value)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            return numbers.TryGetValue(name, out value);
        }

        public T Convert(int value)
        {
            throw new NotImplementedException();
        }
    }
}