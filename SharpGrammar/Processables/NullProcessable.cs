namespace SharpGrammar
{
    /// <summary>
    /// A null-<see cref="Processable"/> that does and produces nothing.
    /// </summary>
    public class NullProcessable : Processable
    {
        /// <inheritdoc />
        public override string Process(IContext context) => context.NullValue;
    }
}