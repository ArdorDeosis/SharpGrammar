using System;

namespace SharpGrammar
{
    /// <summary>
    /// An <see cref="Exception"/> thrown during the processing of a <see cref="Processable"/>.
    /// </summary>
    public class GrammarProcessingException : Exception
    {
        /// <param name="processableTypeName">The name of the type of the <see cref="Processable"/> in which the
        /// exception was thrown.</param>
        /// <param name="message">A message containing information about what went wrong.</param>
        public GrammarProcessingException(string processableTypeName, string message) :
            base($"Exception while processing {processableTypeName}: {message}") { }
    }
}