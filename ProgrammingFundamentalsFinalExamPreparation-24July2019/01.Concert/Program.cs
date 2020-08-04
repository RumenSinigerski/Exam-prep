using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(new string[]{"; ", ", "}, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<string>> bandMembers = new Dictionary<string, List<string>>();
            Dictionary<string, int> bandTimeOnStage = new Dictionary<string, int>();
            int totalTime = 0;

            while (!command.Contains("start of concert"))
            {
                if (command.Contains("Add"))
                {
                    if (!bandMembers.ContainsKey(command[1]))
                    {
                        bandMembers.Add(command[1], new List<string>());
                        bandTimeOnStage.Add(command[1], 0);
                    }
                    for (int i = 2; i < command.Length; i++)
                    {
                        if (!bandMembers[command[1]].Contains(command[i]))
                        {
                            bandMembers[command[1]].Add(command[i]);
                        }
                    }
                }
                else if (command.Contains("Play"))
                {
                    int timeOnStage = int.Parse(command[2]);
                    if (!bandTimeOnStage.ContainsKey(command[1]))
                    {

                        bandMembers.Add(command[1], new List<string>());
                        bandTimeOnStage.Add(command[1], timeOnStage);
                        totalTime += timeOnStage;
                    }
                    else
                    {
                        bandTimeOnStage[command[1]] += timeOnStage;
                        totalTime += timeOnStage;
                    }
                }

                command = Console.ReadLine().Split(new string[] { "; ", ", " }, StringSplitOptions.RemoveEmptyEntries);
            }


            Console.WriteLine($"Total time: {totalTime}");

            bandTimeOnStage = bandTimeOnStage.OrderByDescending(v => v.Value).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var kvp in bandTimeOnStage)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            string band = Console.ReadLine();
            Console.WriteLine(band);
            foreach (var item in bandMembers[band])
            {
                Console.WriteLine(string.Join(Environment.NewLine, $"=> {item}"));
            }

        }
    }
}
