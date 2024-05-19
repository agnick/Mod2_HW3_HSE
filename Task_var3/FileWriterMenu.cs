namespace Task_var3
{
    public static class FileWriterMenu
    {
        /// <summary>
        /// A method that allows the user to enter a filename to save a string to it, the method calls another method to directly write to the file.
        /// </summary>
        /// <param name="toWrite">Line to write to file.</param>
        public static void OpenFileWriterMenu(string toWrite)
        {
            // Declaring a link to a file path.
            string? nPath;

            while (true)
            {
                Console.WriteLine("В файл будут добавлены предложения из выведенных на экран строк файла и аббревиатуры к ним.");
                Console.Write("Введите название файла для сохранения результата. Пример ввода: MyFile.txt: ");
                nPath = Console.ReadLine();

                // Сhecking for exceptions.
                try
                {
                    // Calling a method that writes a line to a file
                    StringUtils.FileWriter.Write(toWrite, nPath);
                    break;
                }
                catch (Exception ex)
                {
                    // Calling a method that outputs a red - marked error.
                    BeautyError.PrintBeautyError($"{ex.Message} Повторите ввод.");
                }
            }
        }
    }
}