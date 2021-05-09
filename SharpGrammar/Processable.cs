namespace SharpGrammar
{
    /// <summary>
    /// Base building block of a <see cref="SharpGrammar"/> grammar. A <see cref="Processable"/> contains all
    /// information needed for itself to be processed with <see cref="Process(IContext)"/>. It is always processed
    /// within a context, provided by an instance of <see cref="IContext"/>.
    /// </summary>
    public abstract class Processable
    {
        /// <summary>
        /// Processes the <see cref="Processable"/> under the given <see cref="IContext"/>.
        /// </summary>
        /// <param name="context">The context in which the processable is processed.</param>
        public abstract string Process(IContext context);

        /// <summary>
        /// Implicitly converts a string to a <see cref="Processable"/>.
        /// </summary>
        public static implicit operator Processable(string value) => new ValueProcessable(value);
        
        /// <summary>
        /// Concatenates two <see cref="Processable"/>s.
        /// </summary>
        public static Processable operator +(Processable lhs, Processable rhs) =>
            ProcessableList.Combine(lhs, rhs);
    }
}