using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MessagesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var msgCapacity = int.Parse(Console.ReadLine());
            var command = Console.ReadLine().Split("=", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, Dictionary<int, int>> usersAndMsgs = new Dictionary<string, Dictionary<int, int>>();

            while (!command.Contains("Statistics"))
            {
                if (command.Contains("Add"))
                {
                    string username = command[1];
                    int sendMsg = int.Parse(command[2]);
                    int receivedMsg = int.Parse(command[3]);
                    if (!usersAndMsgs.ContainsKey(username))
                    {
                        usersAndMsgs.Add(username, new Dictionary<int, int>());
                        usersAndMsgs[username].Add(sendMsg, receivedMsg);
                    }
                }
                else if (command.Contains("Message"))
                {
                    string sender = command[1];
                    string receiver = command[2];

                    if (usersAndMsgs.ContainsKey(sender) && usersAndMsgs.ContainsKey(receiver))
                    {
                        usersAndMsgs[sender]++;
                        usersAndMsgs[receiver]++;

                        if (usersAndMsgs[sender] >= msgCapacity)
                        {
                            usersAndMsgs.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }
                        if (usersAndMsgs[receiver] >= msgCapacity)
                        {
                            usersAndMsgs.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else if (command.Contains("Empty"))
                {
                    string username = command[1];

                    if (username.Contains("All"))
                    {
                        usersAndMsgs = new Dictionary<string, int>();
                    }
                    else if (usersAndMsgs.ContainsKey(username))
                    {
                        usersAndMsgs.Remove(username);
                    }

                }

                command = Console.ReadLine().Split("=", StringSplitOptions.RemoveEmptyEntries);
            }

            usersAndMsgs = usersAndMsgs.OrderByDescending()
        }
    }
}
