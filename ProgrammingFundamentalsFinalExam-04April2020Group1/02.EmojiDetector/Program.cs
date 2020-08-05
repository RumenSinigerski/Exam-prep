using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string patternDigits = @"(?<digit>[0-9])";
            BigInteger trashhold = 1;
            var input = Console.ReadLine();

            Regex regexDigits = new Regex(patternDigits);

            MatchCollection matchDigits = regexDigits.Matches(input);

            foreach (Match item in matchDigits)
            {
                int num = int.Parse(item.Value);
                trashhold *= num;
            }

            Console.WriteLine($"Cool threshold: {trashhold}");

            Regex regexEmoji = new Regex(pattern);

            MatchCollection matchEmojis = regexEmoji.Matches(input);

            Console.WriteLine($"{matchEmojis.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matchEmojis)
            {
                int sum = 0;
                foreach (char item in match.Groups["emoji"].Value)
                {
                    sum += item;
                }


                if (sum > trashhold)
                {
                    Console.WriteLine(match.Value);
                }
            }
        }
    }
}
