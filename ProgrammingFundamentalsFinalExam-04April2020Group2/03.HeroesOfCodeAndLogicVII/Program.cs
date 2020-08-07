using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.HeroesOfCodeAndLogicVII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> heroHPAndMP = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = input[0];
                int hp = int.Parse(input[1]);
                int mp = int.Parse(input[2]);

                heroHPAndMP.Add(name, new List<int>() {hp, mp});
                
            }

            string[] command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            while (!command.Contains("End"))
            {
                if (command.Contains("CastSpell"))
                {
                    string hero = command[1];
                    int mpNeeded = int.Parse(command[2]);
                    string spell = command[3];

                    if (mpNeeded <= heroHPAndMP[hero][1])
                    {
                        heroHPAndMP[hero][1] -= mpNeeded;
                        Console.WriteLine($"{hero} has successfully cast {spell} and now has {heroHPAndMP[hero][1]} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero} does not have enough MP to cast {spell}!");
                    }
                }
                else if (command.Contains("TakeDamage"))
                {
                    string hero = command[1];
                    int damage = int.Parse(command[2]);
                    string attacker = command[3];

                    if (damage < heroHPAndMP[hero][0])
                    {
                        heroHPAndMP[hero][0] -= damage;
                        Console.WriteLine($"{hero} was hit for {damage} HP by {attacker} and now has {heroHPAndMP[hero][0]} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{hero} has been killed by {attacker}!");
                        heroHPAndMP.Remove(hero);
                    }
                }
                else if (command.Contains("Recharge"))
                {
                    string hero = command[1];
                    int amountMP = int.Parse(command[2]);

                    if (amountMP + heroHPAndMP[hero][1] > 200)
                    {                  
                        Console.WriteLine($"{hero} recharged for {200 - heroHPAndMP[hero][1]} MP!");
                        heroHPAndMP[hero][1] = 200;
                    }
                    else
                    {
                        heroHPAndMP[hero][1] += amountMP;
                        Console.WriteLine($"{hero} recharged for {amountMP} MP!");
                    }
                }
                else if (command.Contains("Heal"))
                {
                    string hero = command[1];
                    int amountHP = int.Parse(command[2]);

                    if (amountHP + heroHPAndMP[hero][0] > 100)
                    {                        
                        Console.WriteLine($"{hero} healed for {100 - heroHPAndMP[hero][0]} HP!");
                        heroHPAndMP[hero][0] = 100;
                    }
                    else
                    {
                        heroHPAndMP[hero][0] += amountHP;
                        Console.WriteLine($"{hero} healed for {amountHP} HP!");
                    }
                }


                command = Console.ReadLine().Split(" - ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            heroHPAndMP = heroHPAndMP.OrderByDescending(v => v.Value[0]).ThenBy(k => k.Key).ToDictionary(k => k.Key, v=> v.Value);

            foreach (var item in heroHPAndMP)
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value[0]}");
                Console.WriteLine($"  MP: {item.Value[1]}");
            }
        }
    }
}
