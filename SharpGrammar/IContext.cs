using System;

namespace SharpGrammar
{
    /// <summary>
    /// A context for the grammar to be evaluated in.
    /// Provides random values and memory functionality.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Retrieves a module of type <typeparamref name="T"/>. Throws an exception if no module could be retrieved.
        /// </summary>
        /// <typeparam name="T">Type of the module to retrieve.</typeparam>
        T Get<T>() where T : notnull;

        /// <summary>
        /// Binds an module to the context.
        /// </summary>
        /// <typeparam name="T">Type of the module to be bound.</typeparam>
        /// <returns>itself (for procedural usage)</returns>
        IContext BindModule<T>() where T : class;

        /// <summary>
        /// Binds a module to the context.
        /// </summary>
        /// <typeparam name="T">Type of the module to be bound.</typeparam>
        /// <param name="module">The instance of the module to be bound.</param>
        /// <returns>itself (for procedural usage)</returns>
        IContext BindModule<T>(T module) where T : notnull;

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
    }
}