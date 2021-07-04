using System;
using System.Collections.Generic;

namespace SharpGrammar
{
    /// <summary>
    /// An <see cref="IContextModule"/> providing simple memory functionality.
    /// </summary>
    public interface IMemoryModule : IContextModule
    {
        /// <summary>
        /// Saves the provided <paramref name="value"/> to context-memory with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the variable.</param>
        /// <param name="value">The value of the variable.</param>
        /// <param name="override">Whether the variable should be overridden, if one with the same name already
        /// exists.</param>
        void SetValue(string name, Processable value, bool @override = true);

        /// <summary>
        /// Unsets the variable with the name <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the variable to unset.</param>
        void UnsetValue(string name);

        /// <summary>
        /// Returns the variable named <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the variable to return.</param>
        Processable GetValue(string name);

        /// <summary>
        /// Retrieves the variable named <paramref name="name"/>, if it exists.
        /// </summary>
        /// <param name="name">The name of the variable to return.</param>
        /// <param name="value">Contains the value of the variable if found, null otherwise.</param>
        /// <returns>Whether the variable was found or not.</returns>
        bool TryGetValue(string name, out Processable? value);
    }


    /// <inheritdoc />
    public class MemoryModule : IMemoryModule {
        
        private readonly Dictionary<string, Processable> variables = new();

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="value"/> is null.
        /// </exception>
        public void SetValue(string name, Processable value, bool @override = true)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (!variables.ContainsKey(name))
            {
                variables.Add(name, value);
                return;
            }

            if (@override)
                variables[name] = value;
        }

        /// <inheritdoc />
        public void UnsetValue(string name) => variables.Remove(name);

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">No variable named '<paramref name="name"/>' exists.
        /// </exception>
        public Processable GetValue(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (!variables.ContainsKey(name))
                throw new ArgumentOutOfRangeException($"Variable '{name}' does not exist in this context.");
            return variables[name];
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public bool TryGetValue(string name, out Processable? value)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            return variables.TryGetValue(name, out value);
        }
    }
}