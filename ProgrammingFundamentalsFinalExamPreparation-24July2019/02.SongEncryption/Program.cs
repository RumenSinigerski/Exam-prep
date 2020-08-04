using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<artist>[A-Z][[a-z\'\s]+):(?<song>[A-Z\s]+)$";
            var input = Console.ReadLine();
            Regex regex = new Regex(pattern);

            while (input != "end")
            {
                StringBuilder sb = new StringBuilder();
                Match match = regex.Match(input);
                if (match.Success)
                {
                    string artist = match.Groups["artist"].ToString();
                    string song = match.Groups["song"].ToString();
                    int key = match.Groups["artist"].Length;
                    for (int i = 0; i < artist.Length; i++)
                    {
                        if (artist[i] == ' ' || artist[i] == '\'')
                        {
                            sb.Append(artist[i]);
                            continue;
                        }
                        if (artist[i] + key >= 65 && artist[i] + key <= 90 || artist[i] + key >= 97 && artist[i] + key <= 122)
                        {
                            sb.Append((char)(artist[i] + key));
                        }
                        else
                        {                            
                            sb.Append((char)(artist[i] + key - 26));
                        }

                    }
                    sb.Append("@");

                    for (int i = 0; i < song.Length; i++)
                    {
                        if (song[i] == ' ' || song[i] == '\'')
                        {
                            sb.Append(song[i]);
                            continue;
                        }
                        if (song[i] + key >= 65 && song[i] + key <= 90)
                        {
                            sb.Append((char)(song[i] + key));
                        }
                        else
                        {                           
                            sb.Append((char)(song[i] + key - 26));
                        }
                    }

                    Console.WriteLine($"Successful encryption: {sb}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }
    }
}
