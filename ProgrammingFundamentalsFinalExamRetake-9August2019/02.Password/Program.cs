using System;
using System.Text.RegularExpressions;

namespace _02.Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(.+)>(?<numbers>[0-9]{3})\|(?<lowletters>[a-z]{3})\|(?<upperletters>[A-Z]{3})\|(?<symbols>((?!<>).){3})<\1$";

            int n = int.Parse(Console.ReadLine());

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                string pass = Console.ReadLine();

                Match match = regex.Match(pass);

                if (match.Success)
                {
                    Console.WriteLine($"Password: {match.Groups["numbers"]}{match.Groups["lowletters"]}{match.Groups["upperletters"]}{match.Groups["symbols"]}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }
        }
    }
}
