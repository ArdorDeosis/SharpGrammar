using System;
using System.Collections.Generic;

namespace SharpGrammar
{
    /// <inheritdoc />
    public class Context : IContext
    {
        private readonly Random random;
        private readonly Dictionary<Type, object> modules = new();
        private readonly Dictionary<Type, object> typeContexts = new();

        /// <inheritdoc />
        public int Seed { get; }

        public Context()
        {
            Seed = new Random().Next();
            random = new Random(Seed);
        }

        /// <param name="seed">The seed for the random number generator.</param>
        public Context(int seed)
        {
            Seed = seed;
            random = new Random(seed);
        }

        /// <inheritdoc />
        /// <exception cref="ModuleNotBoundException">When no module of type <typeparamref name="T"/> is bound to this
        /// context.</exception>
        public T Get<T>() where T : notnull
        {
            if (!modules.TryGetValue(typeof(T), out var module))
                throw new ModuleNotBoundException(typeof(T));
            return (T) module;
        }

        /// <inheritdoc />
        /// <exception cref="ContextBindingException">When type <typeparamref name="T"/> does not provide a
        /// parameterless constructor.</exception>
        public IContext BindModule<T>() where T : class
        {
            var constructor = typeof(T).GetConstructor(Type.EmptyTypes) ??
                              throw new ContextBindingException(
                                  $"Type {typeof(T)} does not provide a parameterless constructor and thus " +
                                  "cannot be bound automatically. Please provide an instance to be bound to the " +
                                  "context.");
            var module = constructor.Invoke(new object?[] {this}) as T;
            return BindModule(module!);
        }

        /// <inheritdoc />
        /// <exception cref="ModuleAlreadyBoundException">When a module of type <typeparamref name="T"/> is already
        /// bound to this context.</exception>
        public IContext BindModule<T>(T module) where T : notnull
        {
            if (modules.ContainsKey(typeof(T)))
                throw new ModuleAlreadyBoundException(typeof(T));
            modules.Add(typeof(T), module);
            return this;
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="max"/> is less than 0.</exception>
        public int GetRandomInt(int max)
        {
            if (max < 0)
                throw new ArgumentOutOfRangeException(nameof(max), "Max value can not be less than 0.");
            return random.Next(max);
        }

        /// <inheritdoc />
        /// <exception cref="TypeHandlerAlreadyBoundException">When a <see cref="ITypeHandler{T}"/> for type
        /// <typeparamref name="T"/> is already bound to this context.</exception>
        public IContext BindTypeHandling<T>(ITypeHandler<T> typeHandler)
        {
            if (typeContexts.ContainsKey(typeof(T)))
                throw new TypeHandlerAlreadyBoundException(typeof(T));
            typeContexts.Add(typeof(T), typeHandler);
            return this;
        }

        /// <inheritdoc />
        T IContext.GetNullValue<T>() => GetTypeHandler<T>().NullValue;

        /// <inheritdoc />
        T IContext.Concatenate<T>(T lhs, T rhs) => GetTypeHandler<T>().Concatenate(lhs, rhs);

        private ITypeHandler<T> GetTypeHandler<T>()
        {
            if (!typeContexts.TryGetValue(typeof(T), out var typeContext))
                throw new TypeHandlerNotBoundException(typeof(T));
            return (ITypeHandler<T>) typeContext;
        }
    }
}