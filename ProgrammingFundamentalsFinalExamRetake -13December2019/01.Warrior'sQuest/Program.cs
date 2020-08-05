using System;
using System.Linq;
using System.Text;

namespace _01.Warrior_sQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder skill = new StringBuilder(Console.ReadLine());

            string input;

            while ((input = Console.ReadLine()) != "For Azeroth")
            {
                var command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command.Contains("GladiatorStance"))
                {
                    skill = new StringBuilder(skill.ToString().ToUpper());
                    Console.WriteLine(skill);
                }
                else if (command.Contains("DefensiveStance"))
                {
                    skill = new StringBuilder(skill.ToString().ToLower());
                    Console.WriteLine(skill);
                }
                else if (command.Contains("Dispel"))
                {
                    int index = int.Parse(command[1]);
                    char replacement = char.Parse(command[2]);
                    if (index >= 0 && index < skill.Length)
                    {
                        skill = skill.Replace(skill[index], replacement, index, 1);
                        Console.WriteLine("Success!");
                    }
                    else
                    {
                        Console.WriteLine("Dispel too weak.");
                    }
                }
                else if (command.Contains("Target") && command.Contains("Change"))
                {

                    string firstSubstring = command[2];
                    string secondSubstring = command[3];

                    if (skill.ToString().Contains(firstSubstring))
                    {
                        skill = skill.Replace(firstSubstring, secondSubstring);
                        Console.WriteLine(skill);
                    }


                }
                else if (command.Contains("Target") && command.Contains("Remove"))
                {
                    string substring = command[2];
                    if (skill.ToString().Contains(substring))
                    {
                        int index = skill.ToString().IndexOf(substring);
                        skill = skill.Remove(index, substring.Length);
                        Console.WriteLine(skill);
                    }

                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }

                
            }
        }
    }
}
