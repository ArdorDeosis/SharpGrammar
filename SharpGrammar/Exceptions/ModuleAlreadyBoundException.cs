using System;
using System.Diagnostics.CodeAnalysis;

namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when a module already has been bound to a type on an <see cref="IContext" />.   
    /// </summary>
    public class ModuleAlreadyBoundException : AlreadyBoundException
    {
        /// <param name="type">Type of the already bound module.</param>
        /// <param name="info">Information about the binding that is already bound.</param>
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public ModuleAlreadyBoundException(Type type, BindingInformation info) :
            base($"A module of type {type.Name} has already been bound to this context.", info)
        {
        }
    }
}