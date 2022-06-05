namespace Histogram_MPI
{
    /// <summary>
    /// Class for splitting texts.
    /// </summary>
    public static class TextSplitter
    {
        /// <summary>
        /// Splits a string into n roughly equal parts, not cutting off words.
        /// </summary>
        /// <param name="text">The text to split.</param>
        /// <param name="nChunks">The number of parts wanted.</param>
        /// <returns>An array of strings with roughly the same length.</returns>
        public static string[] SplitIntoChunks(string text, int nChunks)
        {
            int sizePerChunk = text.Length / nChunks;

            string[] result = new string[nChunks];
            // Initialize
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
                    // We reached the end
                    result[currentChunk] = text.Substring(startPosition);
                    finished = true;
                }
                else
                {
                    // Look for the next space -> we dont want to split words
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
