namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when nothing has been bound to a type on an <see cref="IContext" />.  
    /// </summary>
    public class NotBoundException : ContextBindingException
    {
        /// <inheritdoc />
        public NotBoundException(string message) : base(message) { }
    }
}