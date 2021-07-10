using System;

namespace SharpGrammar
{
    /// <summary>
    /// An <see cref="Exception"/> thrown for errors regarding bindings on <see cref="IContext{T}"/>s.
    /// </summary>
    public class ContextBindingException : Exception
    {
        /// <param name="message">A message containing information about what went wrong.</param>
        public ContextBindingException(string message) : base(message) { }
    }
}