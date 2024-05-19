namespace Task_var3
{
    public static class RowsProcessing
    {
        // Constant contains semicolon symbol.
        private static readonly char semicolon = ';';

        /// <summary>
        /// A method that creates instances of classes, adds them to an array of class instances, and calls a method that allows the user to write the results to a file.
        /// </summary>
        /// <param name="rowData">Passed array of file strings.</param>
        public static string ProceedRows(string[] rowData)
        {
            // An array of class instances with the length of the string arrays.
            StringUtils.MyStrings[] myStrings = new StringUtils.MyStrings[rowData.Length];
            // Empty line to append results to file.
            string toWrite = "";

            // Checking for exceptions.
            try
            {
                // Adding instances of a class to an array.
                for (int i = 0; i < rowData.Length; i++)
                {
                    // Instantiating a class with a populated constructor (current row and semicolon).
                    StringUtils.MyStrings myString = new StringUtils.MyStrings(rowData[i], semicolon);
                    // Adding an instance to an array.
                    myStrings[i] = myString;
                }

                // Loop through the elements of an array of class instances.
                for (int i = 0; i < myStrings.Length; i++)
                {
                    // Getting sentenses in row from a class. 
                    string sentense = string.Join(semicolon, myStrings[i].Sentences) + semicolon;
                    // Getting abbreviations from a class.
                    string acro = string.Join(semicolon, myStrings[i].ACRO) + semicolon;
                    // Getting a row from a class.
                    string row = myStrings[i].Row;
                    // Displaying the message to the user only once. The output is done inside the loop, after calling the class, so as not to display a message in case of errors.
                    if (i == 0)
                    {
                        Console.WriteLine("Из файла были получены строки, содержащие предложения.");
                    }
                    // Displaying information about a row and its abbreviations.
                    Console.WriteLine($"Строка из файла: {row} | Предложения в этой строке: {sentense} | Аббревиатуры к предложениям строки: {acro}");
                    // Adding a string and its abbreviations obtained from a class without additional information to an empty string.
                    toWrite += $"{sentense} {acro}\n";
                }

                // Calling a method that allows the user to enter a filename to save a string to it, the method calls another method to directly write to the file.
                FileWriterMenu.OpenFileWriterMenu(toWrite);
            }
            catch (ArgumentException ex)
            {
                // Calling a method that outputs a red - marked error.
                BeautyError.PrintBeautyError(ex.Message);
            }

            return toWrite;
        }
    }
}