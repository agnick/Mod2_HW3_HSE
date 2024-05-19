namespace StringUtils
{
    public static class FileReader
    {
        /// <summary>
        /// A method that reads a txt file and checks its compliance with the variant.
        /// </summary>
        /// <returns>An array of strings read from a file.</returns>
        /// <exception cref="ArgumentException">The exception that the method throws when the file path is incorrectly specified.</exception>
        /// <exception cref="IOException">The exception that the method throws when the file is opened incorrectly and the structure is written.</exception>
        /// <exception cref="Exception">The exception that the method throws when unexpected errors occur.</exception>
        public static string[] Read(string fPath)
        {
            string[] rowData;

            // Сhecking that the file exists.
            if (!File.Exists(fPath))
            {
                // Throwing such an exception because the fpath value is invalid.
                throw new ArgumentException("Файл с таким названием не существует.");
            }

            // Сhecking for exceptions.
            try
            {
                rowData = File.ReadAllLines(fPath);
            }
            catch (ArgumentException ex)
            {
                // Throwing such an exception because the fpath value is invalid.
                throw new ArgumentException("Введено некорректное название файла.");
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

            // Checking that the transferred file is not empty.
            if (rowData.Length == 0)
            {
                // Throwing such an exception because the rowData is empty.
                throw new ArgumentException("Передан пустой файл.");
            }

            return rowData;
        }
    }
}