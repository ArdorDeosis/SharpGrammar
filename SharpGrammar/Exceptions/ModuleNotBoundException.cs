using System;
using System.Diagnostics.CodeAnalysis;

namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when a module has not been bound to a type on an <see cref="IContext" />.   
    /// </summary>
    public class ModuleNotBoundException : NotBoundException
    {
        /// <param name="type">Type of the not-bound module.</param>
        [SuppressMessage("ReSharper", "SuggestBaseTypeForParameter")]
        public ModuleNotBoundException(Type type) :
            base($"No module of type {type.Name} has been bound to this context.")
        {
        }
    }
}