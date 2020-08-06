using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#]|[@])(?<firstword>[A-Za-z]{3,})\1\1(?<secondword>[A-Za-z]{3,})\1";

            var text = Console.ReadLine();

            Regex regex = new Regex(pattern);

            MatchCollection matches = regex.Matches(text);

            List<string> words = new List<string>();

            if (matches.Count > 0)
            {

                Console.WriteLine($"{matches.Count} word pairs found!");
                foreach (Match match in matches)
                {
                    var firstWord = match.Groups["firstword"].Value.ToString();
                    var secondWord = match.Groups["secondword"].Value.ToString();
                    var reversed = new string(secondWord.Reverse().ToArray());
                    if (firstWord == reversed)
                    {
                        words.Add($"{firstWord} <=> {secondWord}");
                    }
                }

                if (words.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", words));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }

            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
