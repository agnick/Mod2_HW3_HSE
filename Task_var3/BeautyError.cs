namespace Task_var3
{
    public static class BeautyError
    {
        /// <summary>
        /// A method that outputs a red - marked error.
        /// </summary>
        /// <param name="errorMessage">Transmitted error message.</param>
        public static void PrintBeautyError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}