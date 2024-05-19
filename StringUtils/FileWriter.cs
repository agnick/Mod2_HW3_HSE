namespace StringUtils
{
    public static class FileWriter
    {
        /// <summary>
        /// A method that writes a string to a file.
        /// </summary>
        /// <param name="line">Line that need to be written to the file.</param>
        /// <param name="nPath">The path to the file.</param>
        /// <exception cref="ArgumentException">The exception that the method throws when the file path is incorrectly specified.</exception>
        /// <exception cref="IOException">The exception that the method throws when the file is opened incorrectly and the structure is written.</exception>
        /// <exception cref="Exception">The exception that the method throws when unexpected errors occur.</exception>
        public static void Write(string line, string nPath)
        {
            // Checking if the file extension is txt.
            if (!nPath.Contains(".txt"))
            {
                // Throwing such an exception because the npath value is invalid.
                throw new ArgumentException("Введено некорректное название для файла.");
            }

            // Сhecking for exceptions.
            try
            {
                // Writing a line to a file.
                File.WriteAllText(nPath, line);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Данные успешно записаны в файл.");
                Console.ResetColor();
            }
            catch (ArgumentException ex)
            {
                // Throwing such an exception because the npath value is invalid.
                throw new ArgumentException("Введено некорректное название для файла.");
            }
            catch (IOException ex)
            {
                // Throwing such an exception due to an error occurring when opening the file and writing the structure.
                throw new IOException("Возникла ошибка при открытии файла и записи структуры.");
            }
            catch (Exception ex)
            {
                // Throwing such an exception to handle all other exceptions.
                throw new Exception("Возникла непредвиденная ошибка.");
            }
        }
    }
}