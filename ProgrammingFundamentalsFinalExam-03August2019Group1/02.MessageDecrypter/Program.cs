using System;
using System.Text.RegularExpressions;

namespace Message_Decrypter___2
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string pattern = @"^(\$|%)(?<tag>[A-Z][a-z]{2,})\1: \[(?<first>[0-9]+)\]\|\[(?<second>[0-9]+)\]\|\[(?<third>[0-9]+)\]\|$";

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string tag = match.Groups["tag"].Value;
                    int first = int.Parse(match.Groups["first"].Value);
                    int second = int.Parse(match.Groups["second"].Value);
                    int third = int.Parse(match.Groups["third"].Value);

                    Console.WriteLine($"{tag}: {(char)first}{(char)second}{(char)third}");

                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }


            }




        }
    }
}
