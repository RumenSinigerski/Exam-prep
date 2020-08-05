using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.P_rates
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> townPopulation = new Dictionary<string, int>();
            Dictionary<string, int> townGold = new Dictionary<string, int>();

            var input = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);

            while (!input.Contains("Sail"))
            {
                string town = input[0];
                int population = int.Parse(input[1]);
                int gold = int.Parse(input[2]);
                if (!townGold.ContainsKey(town))
                {
                    townPopulation.Add(town, population);
                    townGold.Add(town, gold);
                }
                else
                {
                    townPopulation[town] += population;
                    townGold[town] += gold;
                }


                input = Console.ReadLine().Split("||", StringSplitOptions.RemoveEmptyEntries);
            }

            var command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("End"))
            {
                if (command.Contains("Plunder"))
                {
                    string town = command[1];
                    int peopleKilled = int.Parse(command[2]);
                    int goldStolen = int.Parse(command[3]);

                    if (townGold.ContainsKey(town))
                    {
                        townPopulation[town] -= peopleKilled;
                        townGold[town] -= goldStolen;

                        Console.WriteLine($"{town} plundered! {goldStolen} gold stolen, {peopleKilled} citizens killed.");

                        if (townPopulation[town] <= 0 || townGold[town] <= 0)
                        {
                            townPopulation.Remove(town);
                            townGold.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                    }
                }
                else if (command.Contains("Prosper"))
                {
                    string town = command[1];
                    int goldToAdd = int.Parse(command[2]);

                    if (goldToAdd < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    else
                    {
                        townGold[town] += goldToAdd;
                        Console.WriteLine($"{goldToAdd} gold added to the city treasury. {town} now has {townGold[town]} gold.");
                    }
                }

                command = Console.ReadLine().Split("=>", StringSplitOptions.RemoveEmptyEntries);
            }

            if (townGold.Count > 0)
            {
                townGold = townGold.OrderByDescending(v => v.Value).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

                Console.WriteLine($"Ahoy, Captain! There are {townGold.Count} wealthy settlements to go to:");

                foreach (var town in townGold)
                {
                    Console.WriteLine($"{town.Key} -> Population: {townPopulation[town.Key]} citizens, Gold: {town.Value} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }


        }
    }
}
