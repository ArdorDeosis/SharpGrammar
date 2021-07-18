namespace SharpGrammar
{
    /// <summary>
    /// A context for the grammar to be evaluated in.
    /// Provides random number generation and type specific operations.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// The seed used for this contexts random number generation.
        /// </summary>
        int Seed { get; }

        /// <summary>
        /// Returns a random integer between 0 (incl.) and <paramref name="max"/> (excl.). 
        /// </summary>
        int GetRandomInt(int max);
        
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
        /// Binds an <see cref="ITypeHandler{T}"/> to the context to enable it to handle <see cref="Processable{T}"/>s. 
        /// </summary>
        /// <param name="typeHandler">The type handler to be bound.</param>
        /// <typeparam name="T">The type for which the type handler offers handling.</typeparam>
        IContext BindTypeHandler<T>(ITypeHandler<T> typeHandler);

        /// <summary>
        /// Returns the <see cref="ITypeHandler{T}.NullValue"/> of the <see cref="ITypeHandler{T}"/> bound to type
        /// <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Type of the <see cref="ITypeHandler{T}.NullValue"/>.</typeparam>
        T GetNullValue<T>();

        /// <summary>
        /// Concatenates two <see cref="Processable{T}"/>s according to the <see cref="ITypeHandler{T}.Concatenate"/>
        /// function of the <see cref="ITypeHandler{T}"/> bound to type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">Generic type of the <see cref="Processable{T}"/>s to be concatenated.</typeparam>
        T Concatenate<T>(T lhs, T rhs);
    }
}