namespace SharpGrammar.API
{
    /// <summary>
    /// Extension methods for the <see cref="SharpGrammar"/> API.
    /// </summary>
    public static class ApiExtensions
    {
        /// <summary>
        /// Processes the <see cref="Processable"/> with a newly created <see cref="IContext"/>.
        /// </summary>
        public static string Process(this Processable processable) => processable.Process(new Context());
    }
}