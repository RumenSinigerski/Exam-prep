using System;
using System.Linq;

namespace StringManipulator_Group1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("End"))
            {
                if (command.Contains("Translate"))
                {
                    input = RaplaceSymbol(input, command);
                }
                else if (command.Contains("Includes"))
                {
                    Console.WriteLine(IfContainsString(input, command));
                }
                else if (command.Contains("Start"))
                {
                    Console.WriteLine(IfStringStartsWithGiven(input, command));
                }
                else if (command.Contains("Lowercase"))
                {
                    input = input.ToLower();
                    Console.WriteLine(input);
                }
                else if (command.Contains("FindIndex"))
                {
                    FindLastIndexOf(input, command);
                }
                else if (command.Contains("Remove"))
                {
                    input = RemoveFromString(input, command);
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static string RaplaceSymbol(string input, string[] command)
        {
            string oldChar = command[1];
            string newChar = command[2];

            if (input.Contains(oldChar))
            {
                input = input.Replace(oldChar, newChar);
                Console.WriteLine(input);
            }

            return input;
        }

        static bool IfContainsString(string input, string[] command)
        {
            bool contains = false;
            string includedString = command[1];

            if (input.Contains(includedString))
            {
                contains = true;
            }

            return contains;
        }

        static bool IfStringStartsWithGiven(string input, string[] command)
        {
            bool startWithString = false;
            string checkedString = command[1];

            if (input.StartsWith(checkedString))
            {
                startWithString = true;
            }

            return startWithString;
        }

        static void FindLastIndexOf(string input, string[] command)
        {
            string indexToFind = command[1];
            int index = input.LastIndexOf(indexToFind);

            Console.WriteLine(index);
        }

        static string RemoveFromString(string input, string[] command)
        {
            int startIndex = int.Parse(command[1]);
            int count = int.Parse(command[2]);

            if (startIndex >= 0 && startIndex + count < input.Length)
            {
                input = input.Remove(startIndex, count);
            }
            Console.WriteLine(input);
            return input;
        }
    }
}
