using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.TheIsleOfManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<symbol>[#$%*&])(?<racer>[A-Za-z]+)\1=(?<geohashcode>\d+)!!(?<encrypted>.+)$";
            Regex regex = new Regex(pattern);
            var racerInfo = Console.ReadLine();

            while (true)
            {
                Match match = regex.Match(racerInfo);

                if (match.Success)
                {
                    string toParse = match.Groups["geohashcode"].ToString();
                    int geohash = int.Parse(toParse);

                    if (geohash == match.Groups["encrypted"].Length)
                    {
                        string msgToDencrypt = match.Groups["encrypted"].ToString();

                        StringBuilder sb = new StringBuilder();

                        for (int i = 0; i < msgToDencrypt.Length; i++)
                        {
                            sb.Append((char)(msgToDencrypt[i] + geohash));
                        }

                        Console.WriteLine($"Coordinates found! {match.Groups["racer"]} -> {sb}");
                        return;

                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }

                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }

                racerInfo = Console.ReadLine();
            }
        }
    }
}
