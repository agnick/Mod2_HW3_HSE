namespace StringUtils
{
    public static class MySentences
    {
        // Constant contains valid characters in sentence (including space).
        private static readonly string validChars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";

        /// <summary>
        /// A method that returns an array of sentences from a string.
        /// </summary>
        /// <param name="row">The passed string containing or not containing sentences.</param>
        /// <param name="ch">End of sentence symbol.</param>
        /// <returns>Array of sentences.</returns>
        public static string[] GetSentencesFromRow(string row, char ch)
        {
            // Using the abstract List data type to easily store and add new sentences.
            List<string> result = new List<string>();

            /* 
                The condition does not explicitly say whether each row contains sentences, whether there are lines containing both sentences and non-sentences, and other options. 
                Therefore, the following options need to be considered.
                There may be different rows:
                1) Containing only sentences:
                    Example: first sent; second sent;
                2) Containing both sentences and non-sentences:
                    Example 1: first sent; second sent (no semicolon)
                    Example 2: first sent; 2 sent$$$*; (Unacceptable symbols)
                3) Not containing sentences at all:
                    Example 1: (empty string)
                    Example 2: fisrt sent (no semicolon)
                    Example 3: 1 $ent; (Unacceptable symbols) 
                In any case, a version of my solution will also work for the “ideal world”, where each row is the nth number of sentences.
            */

            // Checking that a string contains sentences using a private method.
            if (ContainsSentence(row, ch))
            {
                // Splitting a string using the passed delimiter.
                string[] splittedRow = row.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                /* 
                   It is known that the line contains the desired delimiter (which is the end of the sentence).
                   Which means that all elements of the new array can be checked to see if they are sentences. 
                   We are not sure about the last element (whether there is a separator at the end of it), so we consider it separately.
                */

                // Loop through all array elements except the last one.
                for (int i = 0; i < splittedRow.Length - 1; i++)
                {
                    // Checking whether an array element is a sentence using a private method.
                    if (IsSentence(splittedRow[i]))
                    {
                        // Adding an element to a row sentences array.
                        result.Add(splittedRow[i]);
                    }
                }

                /*
                   The last element is considered separately. 
                   We check that the line ends with a separator (this means that the element can be a sentence because it has an ending).
                   Spaces are removed to avoid a situation where a space accidentally appears at the end of a file line, but it does not affect the number of sentences.
                   We also check that the element does not contain prohibited characters.
                */
                if (row.Replace(" ", "")[^1] == ch && IsSentence(splittedRow[^1]))
                {
                    // Adding an element to a row sentences array.
                    result.Add(splittedRow[^1]);
                }
            }

            // Returning a List type converted to an array.
            return result.ToArray();
        }

        /// <summary>
        /// A method that returns from an array of strings only those strings that contain sentences.
        /// </summary>
        /// <param name="rowdata">Passed array of strings.</param>
        /// <param name="ch">End of sentence symbol.</param>
        /// <returns>Array of rows containing sentences.</returns>
        public static string[] GetRowsContainingSentences(string[] rowdata, char ch)
        {
            // Using the abstract List data type to easily store and add new rows.
            List<string> result = new List<string>();

            // Loop through all rows.
            foreach (string row in rowdata)
            {
                // Checking that a string contains sentences using a private method.
                if (ContainsSentence(row, ch))
                {
                    // Adding an element to a selected rows array.
                    result.Add(row);
                }
            }

            // Returning a List type converted to an array.
            return result.ToArray();
        }

        /// <summary>
        /// A method that checks whether the passed row contains sentences.
        /// </summary>
        /// <param name="row">The passed string containing or not containing sentences.</param>
        /// <param name="ch">End of sentence symbol.</param>
        /// <returns>A boolean variable that is responsible for whether the passed string contains sentences.</returns>
        private static bool ContainsSentence(string row, char ch)
        {
            // Initialization of a logical variable (by default it is considered that there are no sentences in row).
            bool SentenceInRow = false;

            /* 
                The condition does not explicitly say whether each row contains sentences, whether there are lines containing both sentences and non-sentences, and other options. 
                Therefore, the following options need to be considered.
                There may be different rows:
                1) Containing only sentences:
                    Example: first sent; second sent;
                2) Containing both sentences and non-sentences:
                    Example 1: first sent; second sent (no semicolon)
                    Example 2: first sent; 2 sent$$$*; (Unacceptable symbols)
                3) Not containing sentences at all:
                    Example 1: (empty string)
                    Example 2: fisrt sent (no semicolon)
                    Example 3: 1 $ent; (Unacceptable symbols) 
                In any case, a version of my solution will also work for the “ideal world”, where each row is the nth number of sentences.
            */

            /* 
                We check that the passed string is not empty or null and also contains a sentence ending character. 
                Without this ending character, the string cannot contain sentences, as there will always be an invalid character '\n'
                Example: xdxdxd (no semicolon)
            */
            if (!string.IsNullOrEmpty(row) && row.Contains(ch))
            {
                // Splitting a string using the passed delimiter.
                string[] splittedRow = row.Split(ch, StringSplitOptions.RemoveEmptyEntries);

                /* 
                   It is known that the line contains the desired delimiter (which is the end of the sentence).
                   Which means that all elements of the new array can be checked to see if they are sentences. 
                   We are not sure about the single element (whether there is a separator at the end of it), so we consider it separately.
                   Example:
                   1) line
                   2) line; 
                   After splitting by ';' the result will be the same [line] and we can't be sure that this row is sentence. Thats why we need extra checks.
                */

                // Single and multi elements check. We also check that the element does not contain prohibited characters.
                if (splittedRow.Length == 1 && IsSentence(splittedRow[0]))
                {
                    // The sentence is contained in the row.
                    SentenceInRow = true;
                }
                else
                {
                    // Looping through all elements not including the last one.
                    for (int i = 0; i < splittedRow.Length - 1; i++)
                    {
                        // Checking that the element does not contain prohibited characters.
                        if (IsSentence(splittedRow[i]))
                        {
                            // The sentence is contained in the row.
                            SentenceInRow = true;
                        }
                    }
                }
            }

            return SentenceInRow;
        }

        /// <summary>
        /// The method checks whether the row element is a sentence (for invalid characters).
        /// </summary>
        /// <param name="element">A transmitted row element consisting of words.</param>
        /// <returns>A boolean variable that determines whether a row element is a sentence.</returns>
        private static bool IsSentence(string element)
        {
            // Checking to see if each character in a string is valid.
            bool isValid = element.All(c => validChars.Contains(c));

            return isValid;
        }
    }
}