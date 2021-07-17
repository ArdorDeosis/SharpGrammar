using System;

namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when a module already has been bound to a type on an <see cref="IContext" />.   
    /// </summary>
    public class ModuleAlreadyBoundException : AlreadyBoundException
    {
        /// <param name="type">Type of the already bound module.</param>
        public ModuleAlreadyBoundException(Type type) :
            base($"A module of type {type.Name} has already been bound to this context.")
        {
        }
    }
}