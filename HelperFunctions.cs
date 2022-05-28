namespace Histogram_Sequential
{
    public static class HelperFunctions
    {
        /// <summary>
        /// Splits a string into n roughly equal parts, not cutting off words.
        /// </summary>
        /// <param name="text">The string to split.</param>
        /// <param name="nChunks">The number of parts wanted.</param>
        /// <returns>An array of strings with roughly the same count of words.</returns>
        public static string[] SplitIntoChunks(string text, int nChunks)
        {
            var lines = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            return lines.Split(nChunks).Select(p => String.Join(" ", p.ToList())).ToArray();
        }

        /// <summary>
        /// Splits an array into several smaller arrays.
        /// </summary>
        /// <typeparam name="T">The type of the array.</typeparam>
        /// <param name="array">The array to split.</param>
        /// <param name="size">The size of the smaller arrays.</param>
        /// <returns>An array containing smaller arrays.</returns>
        private static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> list, int parts)
        {
            int i = 0;
            var splits = from item in list
                         group item by i++ % parts into part
                         select part.AsEnumerable();
            return splits;
        }

    }
}
