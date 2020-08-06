using System;
using System.Linq;

namespace StringManipulator_Group2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("Done"))
            {
                if (command.Contains("Change"))
                {
                    input = ReplaceAllCharacters(input, command);
                }
                else if (command.Contains("Includes"))
                {
                    CheckIfIncludes(input, command);
                }
                else if (command.Contains("End"))
                {
                    CheckIfEndsWith(input,command);
                }
                else if (command.Contains("Uppercase"))
                {
                    input = input.ToUpper();
                    Console.WriteLine(input);
                }
                else if (command.Contains("FindIndex"))
                {
                    FirstIndexOf(input, command);
                }
                else if (command.Contains("Cut"))
                {
                    input = CutStartAndEnd(input, command);
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }

        static string ReplaceAllCharacters(string text, string[] command)
        {
            string toReplace = command[1];
            string replacement = command[2];

            if (text.Contains(toReplace))
            {
                text = text.Replace(toReplace, replacement);
            }

            Console.WriteLine(text);

            return text;
        }

        static void CheckIfIncludes(string text, string[] command)
        {
            string toCheck = command[1];
            bool isIncluded = false;

            if (text.Contains(toCheck))
            {
                isIncluded = true;
            }

            Console.WriteLine(isIncluded);
        }

        static void CheckIfEndsWith(string text, string[] command)
        {
            string toCheck = command[1];
            bool endsWith = false;

            if (text.EndsWith(toCheck))
            {
                endsWith = true;
            }

            Console.WriteLine(endsWith);
        }

        static void FirstIndexOf(string text, string[] command)
        {
            string ch = command[1];
            if (text.Contains(ch))
            {
                int index = text.IndexOf(ch);
                Console.WriteLine(index);
            }
        }

        static string CutStartAndEnd(string text, string[] command)
        {
            int startIndex = int.Parse(command[1]);
            int lenght = int.Parse(command[2]);

            if (startIndex >= 0 && startIndex + lenght < text.Length)
            {
                text = text.Substring(startIndex, lenght);
            }
            else if (startIndex + lenght >= text.Length)
            {
                text = text.Substring(startIndex);
            }

            Console.WriteLine(text);
            return text;
        }
    }
}
