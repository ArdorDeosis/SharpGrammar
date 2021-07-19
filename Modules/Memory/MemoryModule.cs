using System;
using System.Collections.Generic;

namespace SharpGrammar.Memory
{
    /// <inheritdoc />
    public class MemoryModule : IMemoryModule
    {
        private readonly Dictionary<Type, Dictionary<string, object>> variables = new();

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="value"/> is null.
        /// </exception>
        public void SetValue<T>(string name, Processable<T> value, bool @override = true)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (!variables.ContainsKey(typeof(T)))
                variables.Add(typeof(T), new Dictionary<string, object>());
            if (!variables[typeof(T)].ContainsKey(name))
                variables[typeof(T)].Add(name, value);
            else if (@override)
                variables[typeof(T)][name] = value;
        }

        /// <inheritdoc />
        public void UnsetValue<T>(string name)
        {
            if (!variables.ContainsKey(typeof(T)))
                return;
            variables[typeof(T)].Remove(name);
            if (variables[typeof(T)].Count == 0)
                variables.Remove(typeof(T));
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">No variable of type <typeparamref name="T"/> named
        /// '<paramref name="name"/>' exists.
        /// </exception>
        public Processable<T> GetValue<T>(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (!variables.ContainsKey(typeof(T)))
                throw new ArgumentException($"No variable of type '{typeof(T).Name}' exists in this context.");
            if (!variables[typeof(T)].ContainsKey(name))
                throw new ArgumentOutOfRangeException($"Variable '{name}' does not exist in this context.");
            return (Processable<T>) variables[typeof(T)][name];
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public bool TryGetValue<T>(string name, out Processable<T>? value)
        {
            value = null;
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (!variables.TryGetValue(typeof(T), out var typeDictionary))
                return false;
            if (!typeDictionary.TryGetValue(name, out var valueObject))
                return false;
            value = (Processable<T>) valueObject;
            return true;
        }
    }
}