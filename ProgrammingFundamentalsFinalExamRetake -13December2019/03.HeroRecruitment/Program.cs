using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroRecruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> heroSpells = new Dictionary<string, List<string>>();

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("End"))
            {
                string hero = command[1];
                if (command.Contains("Enroll"))
                {
                    if (!heroSpells.ContainsKey(hero))
                    {
                        heroSpells.Add(hero, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{hero} is already enrolled.");
                    }
                }
                else if (command.Contains("Learn"))
                {
                    string spell = command[2];

                    if (!heroSpells.ContainsKey(hero))
                    {
                        Console.WriteLine($"{hero} doesn't exist.");
                    }
                    else
                    {
                        if (heroSpells[hero].Contains(spell))
                        {
                            Console.WriteLine($"{hero} has already learnt {spell}.");
                        }
                        else
                        {
                            heroSpells[hero].Add(spell);
                        }
                    }
                }
                else if (command.Contains("Unlearn"))
                {
                    string spell = command[2];

                    if (!heroSpells.ContainsKey(hero))
                    {
                        Console.WriteLine($"{hero} doesn't exist.");
                    }
                    else
                    {
                        if (!heroSpells[hero].Contains(spell))
                        {
                            Console.WriteLine($"{hero} doesn't know {spell}.");
                        }
                        else
                        {
                            heroSpells[hero].Remove(spell);
                        }
                    }
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            heroSpells = heroSpells.OrderByDescending(v => v.Value.Count).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine("Heroes:");
            foreach (var item in heroSpells)
            {
                Console.WriteLine($"== {item.Key}: {string.Join(", ", item.Value)}");
            }
        }
    }
}
