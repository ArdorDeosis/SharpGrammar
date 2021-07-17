using System;

namespace SharpGrammar
{
    /// <summary>
    /// Base class for <see cref="Exception"/>s regarding bindings on <see cref="IContext"/>s.
    /// </summary>
    public class ContextBindingException : Exception
    {
        /// <param name="message">A message containing information about what went wrong.</param>
        public ContextBindingException(string message) : base(message) { }
    }
}