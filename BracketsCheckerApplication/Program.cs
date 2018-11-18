using System;
using System.IO;

namespace BracketsCheckerApplication
{
    class Program
    {
        private const string inputFileNamePath = @"C:\input.txt";
        private const string outputFileNamePath = @"C:\output.txt";
        private const string consoleText = "Incorrect formulas were written to output.txt file." +
                                           "\nPress any key to exit the console.";
        private const string exceptionConsoleText = "Please check that input.txt file is present " +
                                                    "in default C:\\ directory.";
        private const string emptyString = "";
        private static string resultText = "";
        private static string[] formulas;

        public static void Main(string[] args)
        {
            // Create an array of formulas
        
            RoundBracketsChecker roundBracketsChecker;
            try
            {
                formulas = ReadFromFile(inputFileNamePath);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(exceptionConsoleText);
                Console.ReadKey();
            }
            

            foreach (string formula in formulas)
            {
                roundBracketsChecker = new RoundBracketsChecker(formula);
                
                // If formula is correct, we will not write it in the file
                if (roundBracketsChecker.Check() != emptyString)
                {
                    // Check brackets and add incorrect formula to resultText string
                    resultText += roundBracketsChecker.Check() + Environment.NewLine;                
                }
            }

            File.WriteAllText(outputFileNamePath, resultText);
            Console.WriteLine(consoleText);
            Console.ReadKey();
        }
        
        public static string[] ReadFromFile(string pathToTheFile)
        {
            string[] lines = File.ReadAllLines(pathToTheFile);
            return lines;
        }
    }
}
