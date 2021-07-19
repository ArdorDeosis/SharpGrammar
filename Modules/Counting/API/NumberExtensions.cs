namespace SharpGrammar.Counting
{
    public static class NumberExtensions
    {
        /// <summary>
        /// Converts the provided integer to an ordinal number string.
        /// </summary>
        /// <param name="number">The integer to convert.</param>
        public static Processable<string> ToOrdinal(this Processable<int> number) => new ToOrdinalProcessable(number);
    }
}