using System;

namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when a <see cref="ITypeHandler{T}"/> already has been bound to a type on an
    /// <see cref="IContext" />.   
    /// </summary>
    public class TypeHandlerAlreadyBoundException : AlreadyBoundException
    {
        /// <param name="type">Type for which a <see cref="ITypeHandler{T}"/> already has been bound.</param>
        public TypeHandlerAlreadyBoundException(Type type) :
            base($"{typeof(ITypeHandler<>)} for type {type.Name} has already been bound to this context.")
        {
        }
    }
}