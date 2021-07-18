using System;
using System.Diagnostics.CodeAnalysis;

namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when a <see cref="ITypeHandler{T}"/> already has been bound to a type on an
    /// <see cref="IContext" />.   
    /// </summary>
    public class TypeHandlerAlreadyBoundException : AlreadyBoundException
    {
        /// <param name="type">Type for which a <see cref="ITypeHandler{T}"/> already has been bound.</param>
        /// <param name="info">Information about the binding that is already bound.</param>
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public TypeHandlerAlreadyBoundException(Type type, BindingInformation info) :
            base($"{typeof(ITypeHandler<>)} for type {type.Name} has already been bound to this context.", info)
        {
        }
    }
}