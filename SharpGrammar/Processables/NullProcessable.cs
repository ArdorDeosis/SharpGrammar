namespace SharpGrammar
{
    /// <summary>
    /// A null-<see cref="Processable{T}"/> that does and produces nothing.
    /// </summary>
    public record NullProcessable<T> : Processable<T>
    {
        /// <inheritdoc />
        public override T Process(IContext context) => context.GetNullValue<T>();
    }
}