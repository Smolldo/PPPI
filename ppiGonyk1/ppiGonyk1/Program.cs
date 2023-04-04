using System;
using System.IO;

namespace ppiGonyk1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("Choose opt:");
                Console.WriteLine("1. Amount of words in \"Lorem ipsum\"");
                Console.WriteLine("2. Math");
                Console.WriteLine("3. Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CountWordsInLoremIpsum();
                        break;
                    case 2:
                        PerformMathOperation();
                        break;
                    case 3:
                        Console.WriteLine("Arrivederci!");
                        break;
                    default:
                        Console.WriteLine("Wrong Action!!!!!!!!!!!!!!");
                        break;
                }

                Console.WriteLine();
            } while (choice != 3);
        }

        static void CountWordsInLoremIpsum()
        {
            string filePath = "E:/LR7/ppi/lorem.txt";

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} not found.");
                return;
            }

            string text = File.ReadAllText(filePath);

            int wordCount = text.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;

            Console.WriteLine($"Amount of words: {wordCount}");
        }

        static void PerformMathOperation()
        {
            Console.WriteLine("Enter mathematical operations:");
            string expression = Console.ReadLine();

                double result = Convert.ToDouble(new System.Data.DataTable().Compute(expression, null));
                Console.WriteLine($"Result: {result}");
        }
    }
}
