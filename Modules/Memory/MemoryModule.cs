using System;
using System.Collections.Generic;

namespace SharpGrammar.Memory
{
    /// <inheritdoc />
    public class MemoryModule<T> : IMemoryModule<T> {
        
        private readonly Dictionary<string, Processable<T>> variables = new();

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="value"/> is null.
        /// </exception>
        public void SetValue(string name, Processable<T> value, bool @override = true)
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
        public Processable<T> GetValue(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (!variables.ContainsKey(name))
                throw new ArgumentOutOfRangeException($"Variable '{name}' does not exist in this context.");
            return variables[name];
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public bool TryGetValue(string name, out Processable<T>? value)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            return variables.TryGetValue(name, out value);
        }
    }
}