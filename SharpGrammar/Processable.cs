namespace SharpGrammar
{
    /// <summary>
    /// Base building block of a <see cref="SharpGrammar"/> grammar. A <see cref="Processable{T}"/> contains all
    /// information needed for itself to be processed with <see cref="Process"/>. It is always processed
    /// within a context, provided by an instance of <see cref="IContext{T}"/>.
    /// </summary>
    /// <typeparam name="T">Return type of the processable.</typeparam>
    public abstract class Processable<T>
    {
        /// <summary>
        /// Processes the <see cref="Processable{T}"/> under the given <see cref="IContext{T}"/>.
        /// </summary>
        /// <param name="context">The context in which the processable is processed.</param>
        public abstract T Process(IContext<T> context);

        /// <summary>
        /// Implicitly converts a string to a <see cref="Processable{T}"/>.
        /// </summary>
        public static implicit operator Processable<T>(T value) => new ValueProcessable<T>(value);
        
        /// <summary>
        /// Concatenates two <see cref="Processable{T}"/>s.
        /// </summary>
        public static Processable<T> operator +(Processable<T> lhs, Processable<T> rhs) =>
            ProcessableList<T>.Combine(lhs, rhs);
    }
}