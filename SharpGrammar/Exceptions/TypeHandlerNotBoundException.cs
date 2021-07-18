using System;
using System.Diagnostics.CodeAnalysis;

namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when no <see cref="ITypeHandler{T}"/> has been bound to a type on an
    /// <see cref="IContext" />.   
    /// </summary>
    public class TypeHandlerNotBoundException : NotBoundException
    {
        /// <param name="type">Type for which no <see cref="ITypeHandler{T}"/> has been bound.</param>
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public TypeHandlerNotBoundException(Type type) :
            base($"No {typeof(ITypeHandler<>)} for type {type.Name} has been bound to this context.")
        {
        }
    }
}