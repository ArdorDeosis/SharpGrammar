namespace SharpGrammar.Iteration
{
    internal static class Extensions
    {
        /// <summary>
        /// Shuffles the given array.
        /// </summary>
        internal static void Shuffle<T, TContext>(this T[] array, IContext<TContext> context)
        {
            var n = array.Length;
            while (n > 1)
            {
                var k = context.GetRandomNumber(n--);
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}