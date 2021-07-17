using System;

namespace SharpGrammar
{
    /// <summary>
    /// A generic interface providing type specific operations and values.
    /// Can be 
    /// </summary>
    /// <typeparam name="T">The type to handle.</typeparam>
    public interface ITypeHandler<T>
    {
        /// <summary>
        /// The null-value of this context returned by <see cref="Processable{T}"/>s that don't produce any value.
        /// </summary>
        T NullValue { get; }

        /// <summary>
        /// The method to concatenate two <see cref="Processable{T}"/>s.
        /// </summary>
        Func<T, T, T> Concatenate { get; }
    }
}