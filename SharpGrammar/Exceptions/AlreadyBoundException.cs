namespace SharpGrammar
{
    /// <summary>
    /// An exception that is thrown when something already has been bound to a type on an <see cref="IContext" />.  
    /// </summary>
    public class AlreadyBoundException : ContextBindingException
    {
        /// <inheritdoc />
        public AlreadyBoundException(string message) : base(message) { }
    }
}