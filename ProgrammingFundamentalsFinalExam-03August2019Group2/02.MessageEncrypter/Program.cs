using System;
using System.Text.RegularExpressions;

namespace _02.MessageEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([*]|[@])(?<tag>[A-Z][a-z]{2,})\1: (?<msg>(\[[A-Za-z]\]\|){3}?)$";

            Regex regex = new Regex(pattern);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();

                Match match = regex.Match(message);

                if (match.Success)
                {
                    char[] encrypted = match.Groups["msg"].Value.ToCharArray();
                    Console.Write($"{match.Groups["tag"].Value}: ");
                    for (int j = 0; j < encrypted.Length; j++)
                    {
                        if (Char.IsLetter(encrypted[j]))
                        {
                            Console.Write($"{(int)encrypted[j]} ");
                        }
                    }
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
