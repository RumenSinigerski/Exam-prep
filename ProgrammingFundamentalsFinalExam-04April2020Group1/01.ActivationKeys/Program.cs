using System;
using System.Linq;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Console.ReadLine();
            var instructions = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);

            while (!instructions.Contains("Generate"))
            {
                if (instructions.Contains("Contains"))
                {
                    string substring = instructions[1];

                    if (key.Contains(substring))
                    {
                        Console.WriteLine($"{key} contains {substring}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (instructions.Contains("Flip"))
                {
                    
                    if (instructions.Length == 3)
                    {
                        int startIndex = int.Parse(instructions[2]);

                        if (instructions.Contains("Upper"))
                        {
                            key = key.Substring(0, startIndex) + key.Substring(startIndex).ToUpper();
                        }
                        else if (instructions.Contains("Lower"))
                        {
                            key = key.Substring(0, startIndex) + key.Substring(startIndex).ToLower();
                        }

                    }
                    else
                    {
                        int startIndex = int.Parse(instructions[2]);
                        int endIndex = int.Parse(instructions[3]);                      

                        if (instructions.Contains("Upper"))
                        {
                            key = key.Substring(0, startIndex) + key.Substring(startIndex, endIndex - startIndex).ToUpper() + key.Substring(endIndex);
                        }
                        else if (instructions.Contains("Lower"))
                        {
                            key = key.Substring(0, startIndex) + key.Substring(startIndex, endIndex - startIndex).ToLower() + key.Substring(endIndex);
                        }

                    }

                    Console.WriteLine(key);
                }
                else if (instructions.Contains("Slice"))
                {
                    if (instructions.Length == 2)
                    {
                        int startIndex = int.Parse(instructions[1]);

                        key = key.Substring(0, startIndex);
                    }
                    else
                    {
                        int startIndex = int.Parse(instructions[1]);
                        int endIndex = int.Parse(instructions[2]);

                        key = key.Substring(0, startIndex) + key.Substring(endIndex);

                    }

                    Console.WriteLine(key);

                }               

                instructions = Console.ReadLine().Split(">>>", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
