using System.Diagnostics.CodeAnalysis;

namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when something already has been bound to a type on an <see cref="IContext" />.  
    /// </summary>
    public class AlreadyBoundException : ContextBindingException
    {
        /// <inheritdoc />
        /// <param name="info">Information about the binding that is already bound.</param>
        [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
        public AlreadyBoundException(string message, BindingInformation info) :
            base($"{message} An instance of {info.BoundInstance.GetType().Name} was bound:\n{info.StackTrace}") { }
    }
}