namespace SharpGrammar
{
    internal static class Extensions
    {
        /// <summary>
        /// Shuffles the given array.
        /// </summary>
        internal static void Shuffle<T>(this T[] array, IContext context)
        {
            var n = array.Length;
            while (n > 1) 
            {
                var k = context.GetRandomInt(n--);
                var temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}