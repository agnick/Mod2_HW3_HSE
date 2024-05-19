/*
   Студент:     Агафонов Никита Максимович    
   Группа:      БПИ234
   Вариант:     3
   Дата:        30.11.2023
*/
namespace Task_var3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                // User input of absolute file path.
                Console.Write("Введите абсолютный путь к файлу с данными: ");
                string? path = Console.ReadLine();

                // Initializing a reference to an array of strings that will be obtained from the file (temporarily null).
                string[]? rowData = null;

                // Сhecking for exceptions.
                try
                {
                    // Calling a method to validate and read a user-supplied txt file.
                    string[] rowDataFromFile = StringUtils.FileReader.Read(path);
                    // Calling a method that returns from an array of strings only those strings that contain sentences.
                    rowData = StringUtils.MySentences.GetRowsContainingSentences(rowDataFromFile, ';');
                }
                catch (Exception ex)
                {
                    // Calling a method that outputs a red - marked error.
                    BeautyError.PrintBeautyError(ex.Message);
                }

                // Сhecking that the returned array is not null and not empty. In case array is not null, but empty there are no "sentences" in file rows.
                if (rowData is not null && rowData.Length != 0)
                {
                    // Calling a method that processes rows received from a file and returns a string consisting of sentences and their abbreviations.
                    RowsProcessing.ProceedRows(rowData);
                }
                else if (rowData is not null && rowData.Length == 0)
                {
                    // Calling a method that outputs a red - marked error.
                    BeautyError.PrintBeautyError("В файле не найдено строк, содержащих предложения.");
                }

                // Repeating the solution at the user's request.
                Console.Write("Для выхода из программы нажмите клавишу ESC, для перезапуска программы нажмите любую другую клавишу: ");
                if (Console.ReadKey(true).Key == ConsoleKey.Escape) { break; }
            }
        }
    }
}