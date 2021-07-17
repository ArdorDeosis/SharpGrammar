namespace SharpGrammar
{
    /// <summary>
    /// A generic interface providing type specific operations and values. Can be bound to an <see cref="IContext"/>
    /// to enable it to handle <see cref="Processable{T}"/>s of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to handle.</typeparam>
    public interface ITypeHandler<T>
    {
        /// <summary>
        /// The null-value of this context returned by <see cref="Processable{T}"/>s that don't produce any value.
        /// </summary>
        T NullValue { get; }

        /// <summary>
        /// The method to concatenate two instances of <typeparamref name="T"/>.
        /// </summary>
        T Concatenate(T lhs, T rhs);
    }
}