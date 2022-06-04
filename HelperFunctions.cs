namespace Histogram_MPI
{
    /// <summary>
    /// Class for helper functions.
    /// </summary>
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
            int sizePerChunk = text.Length / nChunks;

            string[] result = new string[nChunks];
            for (int i = 0; i < nChunks; i++)
            {
                result[i] = "";
            }

            int endPosition = 0;
            int currentChunk = 0;
            bool finished = false;
            while (!finished)
            {
                int startPosition = endPosition;
                endPosition = startPosition + sizePerChunk;
                if (currentChunk == (nChunks - 1) || endPosition >= text.Length)
                {
                    result[currentChunk] = text.Substring(startPosition);
                    finished = true;
                }
                else
                {
                    while (text[endPosition] != ' ')
                    {
                        endPosition++;
                        if (endPosition >= text.Length)
                        {
                            // if the last word reaches the end of the text, stop
                            finished = true;
                            break;
                        }
                    }
                    result[currentChunk] = text[startPosition..endPosition];

                }

                currentChunk++;
            }
            return result;
        }

    }
}
