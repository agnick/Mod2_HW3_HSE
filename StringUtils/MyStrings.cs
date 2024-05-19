namespace StringUtils
{
    public class MyStrings
    {
        // Private field for storing an array of file string sentences.
        private string[] _sentences;
        // Private field for storing the passed row.
        private string _row;

        // Property to read the _sentences field.
        public string[] Sentences => _sentences;

        // Property to read the _row field.
        public string Row => _row;

        // Class constructor.
        public MyStrings(string str, char ch)
        {
            // Checking that the passed file path is not null and is not empty or an empty character.
            if (string.IsNullOrEmpty(str) || ch == '\0')
            {
                // Throwing such an exception because the argument passed is invalid.
                throw new ArgumentException("Ошибка в конструкторе.");
            }

            /* 
                The condition does not explicitly say whether the passed string should consist only of sentences, it only says that it must contain sentences.
                If the row contains only sentences, then only those sentences will be written to the field. 
                But if the row contains both sentences and non-sentences, then only the sentences of the row will be written into the field.
                This is done because the sentences field must clearly contain only sentences, otherwise the task is meaningless.
            */

            // Calling a method that selects only sentences from a string.
            string[] sentences = MySentences.GetSentencesFromRow(str, ch);
            // Received an array of strings is associated with a field reference.
            _sentences = sentences;
            // Assigning the passed string to a private field to save it.
            _row = str;
        }

        // Empty class constructor. Needed in the criteria, so I just assign an empty elements.
        public MyStrings()
        {
            // Received an empty array of strings is associated with a field reference.
            _sentences = Array.Empty<string>();
            // Received an empty string is associated with a field reference.
            _row = string.Empty;
        }

        // Property that returns string sentence abbreviations.
        public string[] ACRO
        {
            get
            {
                // Checking that the passed array of strings is not empty and not equal to null.
                if (_sentences is null || _sentences.Length == 0)
                {
                    // Throwing such an exception because the field value is invalid.
                    throw new ArgumentException("Ошибка при обращении к свойству. Пустая строка.");
                }

                // Calling a method that returns string sentence abbreviations.
                string[] abbreviations = getAbbreviations(_sentences);

                return abbreviations;
            }
        }

        /// <summary>
        /// A private method that returns abbreviations of sentences. The method is private because it is used only inside the class
        /// </summary>
        /// <param name="sentences">Passed array of string sentences.</param>
        /// <returns>An array of sentences abbreviations.</returns>
        private string[] getAbbreviations(string[] sentences)
        {
            // Using the abstract List data type to easily store and add new abbreviations.
            List<string> abbreviations = new List<string>();

            // Loop through an array of sentences.
            foreach (string sentence in sentences)
            {
                // Dividing a sentence into words array.
                string[] words = sentence.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                // Empty string to store sentence abbreviation.
                string abbreviation = "";
                // Loop through an array of words.
                foreach (string word in words)
                {
                    // Adding abbreviations of words by selecting the first letter of the word and capitalizing it.
                    abbreviation += char.ToUpper(word[0]);
                }
                // Adding new abbreviations to array.
                abbreviations.Add(abbreviation);
            }

            return abbreviations.ToArray();
        }
    }
}