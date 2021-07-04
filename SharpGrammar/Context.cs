using System;
using System.Collections.Generic;

namespace SharpGrammar
{
    /// <summary>
    /// A context for the grammar to be evaluated in.
    /// Provides random values and memory functionality.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Retrieves an <see cref="IContextModule"/> of type <typeparamref name="T"/>. Throws an exception
        /// if no module could be retrieved.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="IContextModule"/> to retrieve.</typeparam>
        IContextModule Get<T>() where T : IContextModule;

        /// <summary>
        /// Binds an <see cref="IContextModule"/> to the context.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="IContextModule"/> to be bound.</typeparam>
        /// <returns>itself (for procedural usage)</returns>
        IContext BindModule<T>() where T : class, IContextModule;

        /// <summary>
        /// Binds an <see cref="IContextModule"/> to the context.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="IContextModule"/> to be bound.</typeparam>
        /// <param name="module">The instance of <see cref="IContextModule"/> to be bound.</param>
        /// <returns>itself (for procedural usage)</returns>
        IContext BindModule<T>(T module) where T : IContextModule;
        
        /// <summary>
        /// The null-value of this context returned by <see cref="Processable"/>s that don't produce any value.
        /// </summary>
        string NullValue { get; }
        
        /// <summary>
        /// The method to concatenate two <see cref="Processable"/>s.
        /// </summary>
        Func<string, string, string> Concatenate { get; }
        
        /// <summary>
        /// Returns a random integer between 0 (incl.) and <paramref name="max"/> (excl.). 
        /// </summary>
        int GetRandomInt(int max);
        
        /// <summary>
        /// Returns a random integer between <paramref name="min"/> (incl.) and <paramref name="max"/> (excl.). 
        /// </summary>
        int GetRandomInt(int min, int max);

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
    }

    /// <inheritdoc />
    public class Context : IContext
    {
        private readonly Random random;
        private readonly Dictionary<Type, IContextModule> modules = new();
        
        private readonly Dictionary<string, Processable> variables = new();
        private readonly Dictionary<string, int> numbers = new();

        public Context()
        {
            random = new Random();
        }

        /// <param name="seed">The seed for the random number generator.</param>
        public Context(int seed)
        {
            random = new Random(seed);
        }

        /// <inheritdoc />
        public IContextModule Get<T>() where T : IContextModule =>
            modules.TryGetValue(typeof(T), out var module)
                ? module
                : throw new Exception($"No module of type {typeof(T)} bound to the current context.");

        /// <inheritdoc />
        public IContext BindModule<T>() where T : class, IContextModule
        {
            var constructor = typeof(T).GetConstructor(new []{typeof(IContext)})
                              ?? throw new Exception($"Type {typeof(T)} does not provide a constructor with one " +
                                                     $"parameter of type {typeof(IContext)} and thus cannot be bound " +
                                                     "automatically. Please provide an instance to be bound to the " +
                                                     "context.");
            var module = constructor.Invoke(new object?[]{this}) as T
                          ?? throw new Exception($"Could not instantiate instance of type {typeof(T)} " +
                                                 $"from parameterless constructor.");
            return BindModule(module);
        }

        /// <inheritdoc />
        public IContext BindModule<T>(T module) where T : IContextModule
        {
            if (modules.ContainsKey(typeof(T)))
                throw new Exception($"Module of type {typeof(T)} is already bound to the context.");
            modules.Add(typeof(T), module);
            return this;
        }

        /// <inheritdoc />
        public string NullValue => string.Empty;

        /// <inheritdoc />
        public Func<string, string, string> Concatenate => string.Concat; 

        /// <inheritdoc />
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is less than 0.</exception>
        public int GetRandomInt(int max)
        {
            if (max < 0)
                throw new ArgumentOutOfRangeException(nameof(max), "Max value can not be less than 0.");
            return random.Next(max);
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="min"/> is greater than <paramref name="max"/>.
        /// </exception>
        public int GetRandomInt(int min, int max)
        {
            if (max < min)
                throw new ArgumentOutOfRangeException(nameof(min), "Min value can not be greater than max value");
            return random.Next(min, max);
        }

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