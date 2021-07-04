using System;
using System.Collections.Generic;

namespace SharpGrammar
{
    /// <inheritdoc />
    public class Context : IContext
    {
        private readonly Random random;
        private readonly Dictionary<Type, object> modules = new();

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
        public T Get<T>() where T : notnull
        {
            if (!modules.TryGetValue(typeof(T), out var module))
                throw new ContextBindingException($"No module of type {typeof(T)} is bound to the current context.");
            return (T) module ??
                   throw new ContextBindingException($"Module bound to type {typeof(T)} is not of type {typeof(T)}.");
        }

        /// <inheritdoc />
        public IContext BindModule<T>() where T : class
        {
            var constructor = typeof(T).GetConstructor(Type.EmptyTypes) ??
                              throw new ContextBindingException($"Type {typeof(T)} does not provide a " +
                                                                "parameterless constructor and thus cannot be bound " +
                                                                "automatically. Please provide an instance to be bound " +
                                                                "to the context.");
            var module = constructor.Invoke(new object?[] {this}) as T ??
                         throw new ContextBindingException("Could not instantiate instance of type " +
                                                           $"{typeof(T)} from parameterless constructor.");
            return BindModule(module);
        }

        /// <inheritdoc />
        public IContext BindModule<T>(T module) where T : notnull
        {
            if (modules.ContainsKey(typeof(T)))
                throw new ContextBindingException($"Module of type {typeof(T)} is already bound to the context.");
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
    }
}