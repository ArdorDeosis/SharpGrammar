using System;
using System.Collections.Generic;

namespace SharpGrammar.Counting
{
    /// <inheritdoc />
    public class NumberModule : INumberModule
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
    }
}