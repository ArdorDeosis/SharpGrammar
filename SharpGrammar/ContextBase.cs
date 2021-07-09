using System;
using System.Collections.Generic;

namespace SharpGrammar
{
    /// <inheritdoc />
    public abstract class ContextBase<T> : IContext<T>
    {
        private readonly Random random;
        private readonly Dictionary<Type, object> modules = new();

        public ContextBase()
        {
            random = new Random();
        }

        /// <param name="seed">The seed for the random number generator.</param>
        public ContextBase(int seed)
        {
            random = new Random(seed);
        }

        /// <inheritdoc />
        public TModule Get<TModule>() where TModule : notnull
        {
            if (!modules.TryGetValue(typeof(TModule), out var module))
                throw new ContextBindingException($"No module of type {typeof(TModule)} is bound to the current context.");
            return (TModule) module ??
                   throw new ContextBindingException($"Module bound to type {typeof(TModule)} is not of type {typeof(TModule)}.");
        }

        /// <inheritdoc />
        public IContext<T> BindModule<TModule>() where TModule : class
        {
            var constructor = typeof(TModule).GetConstructor(Type.EmptyTypes) ??
                              throw new ContextBindingException($"Type {typeof(TModule)} does not provide a " +
                                                                "parameterless constructor and thus cannot be bound " +
                                                                "automatically. Please provide an instance to be bound " +
                                                                "to the context.");
            var module = constructor.Invoke(new object?[] {this}) as TModule ??
                         throw new ContextBindingException("Could not instantiate instance of type " +
                                                           $"{typeof(TModule)} from parameterless constructor.");
            return BindModule(module);
        }

        /// <inheritdoc />
        public IContext<T> BindModule<TModule>(TModule module) where TModule : notnull
        {
            if (modules.ContainsKey(typeof(TModule)))
                throw new ContextBindingException($"Module of type {typeof(TModule)} is already bound to the context.");
            modules.Add(typeof(TModule), module);
            return this;
        }

        /// <inheritdoc />
        public abstract T NullValue { get; }

        /// <inheritdoc />
        public abstract Func<T, T, T> Concatenate { get; }

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