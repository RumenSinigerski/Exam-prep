using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BattleManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> fighterHealtAndEnergy = new Dictionary<string, List<int>>();

            var command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("Results"))
            {
                if (command.Contains("Add"))
                {
                    string fighter = command[1];
                    int health = int.Parse(command[2]);
                    int energy = int.Parse(command[3]);

                    if (!fighterHealtAndEnergy.ContainsKey(fighter))
                    {
                        fighterHealtAndEnergy.Add(fighter, new List<int>() { 0, energy });
                    }

                    fighterHealtAndEnergy[fighter][0] += health;
                }
                else if (command.Contains("Attack"))
                {
                    string attacker = command[1];
                    string defender = command[2];
                    int damage = int.Parse(command[3]);

                    if (fighterHealtAndEnergy.ContainsKey(attacker) && fighterHealtAndEnergy.ContainsKey(defender))
                    {
                        fighterHealtAndEnergy[attacker][1]--;
                        fighterHealtAndEnergy[defender][0] -= damage;

                        if (fighterHealtAndEnergy[defender][0] <= 0)
                        {
                            fighterHealtAndEnergy.Remove(defender);
                            Console.WriteLine($"{defender} was disqualified!");
                        }
                        if (fighterHealtAndEnergy[attacker][1] <= 0)
                        {
                            fighterHealtAndEnergy.Remove(attacker);
                            Console.WriteLine($"{attacker} was disqualified!");
                        }
                    }
                }
                else if (command.Contains("Delete"))
                {
                    string fighter = command[1];
                    if (command.Contains("All"))
                    {
                        fighterHealtAndEnergy.Clear();
                    }
                    if (fighterHealtAndEnergy.ContainsKey(fighter))
                    {
                        fighterHealtAndEnergy.Remove(fighter);
                    }
                }

                command = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

            }

            fighterHealtAndEnergy = fighterHealtAndEnergy.OrderByDescending(v => v.Value[0]).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"People count: {fighterHealtAndEnergy.Count}");

            foreach (var item in fighterHealtAndEnergy)
            {
                Console.WriteLine($"{item.Key} - {item.Value[0]} - {item.Value[1]}");
            }
        }
    }
}
