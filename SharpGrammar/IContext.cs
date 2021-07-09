using System;

namespace SharpGrammar
{
    /// <summary>
    /// A context for the grammar to be evaluated in.
    /// Provides random values and memory functionality.
    /// </summary>
    public interface IContext<T>
    {
        /// <summary>
        /// Retrieves a module of type <typeparamref name="T"/>. Throws an exception if no module could be retrieved.
        /// </summary>
        /// <typeparam name="TModule">Type of the module to retrieve.</typeparam>
        TModule Get<TModule>() where TModule : notnull;

        /// <summary>
        /// Binds an module to the context.
        /// </summary>
        /// <typeparam name="TModule">Type of the module to be bound.</typeparam>
        /// <returns>itself (for procedural usage)</returns>
        IContext<T> BindModule<TModule>() where TModule : class;

        /// <summary>
        /// Binds a module to the context.
        /// </summary>
        /// <typeparam name="TModule">Type of the module to be bound.</typeparam>
        /// <param name="module">The instance of the module to be bound.</param>
        /// <returns>itself (for procedural usage)</returns>
        IContext<T> BindModule<TModule>(TModule module) where TModule : notnull;

        /// <summary>
        /// The null-value of this context returned by <see cref="Processable"/>s that don't produce any value.
        /// </summary>
        T NullValue { get; }

        /// <summary>
        /// The method to concatenate two <see cref="Processable"/>s.
        /// </summary>
        Func<T, T, T> Concatenate { get; }

        /// <summary>
        /// Returns a random integer between 0 (incl.) and <paramref name="max"/> (excl.). 
        /// </summary>
        int GetRandomInt(int max);
    }
}