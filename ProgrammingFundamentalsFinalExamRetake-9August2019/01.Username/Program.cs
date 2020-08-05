using System;
using System.Linq;

namespace _01.Username
{
    class Program
    {
        static void Main(string[] args)
        {
            var username = Console.ReadLine();

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Sign")
            {
                if (command.Contains("Case"))
                {
                    if (command[1] == "lower")
                    {
                        username = username.ToLower();
                    }
                    else
                    {
                        username = username.ToUpper();
                    }

                    Console.WriteLine(username);
                }
                else if (command.Contains("Reverse"))
                {
                    int startIndex = int.Parse(command[1]);
                    int endIndex = int.Parse(command[2]);
                    if (startIndex >= 0 && endIndex < username.Length)
                    {
                        char[] toRevert = username.Substring(startIndex, endIndex - startIndex + 1).ToCharArray();
                        toRevert = toRevert.Reverse().ToArray();
                        Console.WriteLine(toRevert);
                    }
                }
                else if (command.Contains("Cut"))
                {
                    string substring = command[1];

                    if (username.Contains(substring))
                    {
                        int index = username.IndexOf(substring);
                        if (index + substring.Length >= username.Length)
                        {
                            username = username.Remove(index);
                        }
                        else
                        {
                            username = username.Remove(index, substring.Length);
                        }
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }

                }
                else if (command.Contains("Replace"))
                {
                    char letter = char.Parse(command[1]);
                    username = username.Replace(letter, '*');

                    Console.WriteLine(username);
                }
                else if (command.Contains("Check"))
                {
                    char ch = char.Parse(command[1]);
                    if (username.Contains(ch))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {ch}.");
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
