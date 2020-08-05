using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Followers
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, List<int>> followersCommentsAndLikes = new Dictionary<string, List<int>>();

            while (!command.Contains("Log out"))
            {
                if (command.Contains("New follower"))
                {
                    string user = command[1];
                    if (!followersCommentsAndLikes.ContainsKey(user))
                    {
                        followersCommentsAndLikes.Add(user, new List<int>() {0, 0});
                    }

                }
                else if (command.Contains("Like"))
                {
                    string user = command[1];
                    int likes = int.Parse(command[2]);

                    if (!followersCommentsAndLikes.ContainsKey(user))
                    {
                        followersCommentsAndLikes.Add(user, new List<int>() {0, 0});
                    }
                    followersCommentsAndLikes[user][0] += likes;
                }
                else if (command.Contains("Comment"))
                {
                    string user = command[1];    

                    if (!followersCommentsAndLikes.ContainsKey(user))
                    {
                        followersCommentsAndLikes.Add(user, new List<int>() { 0, 0});
                    }
                    followersCommentsAndLikes[user][1]++;
                }
                else if (command.Contains("Blocked"))
                {
                    string user = command[1];

                    if (followersCommentsAndLikes.ContainsKey(user))
                    {
                        followersCommentsAndLikes.Remove(user);
                    }
                    else
                    {
                        Console.WriteLine($"{user} doesn't exist.");
                    }
                }

                command = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            }

            followersCommentsAndLikes = followersCommentsAndLikes.OrderByDescending(v => v.Value[0]).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            Console.WriteLine($"{followersCommentsAndLikes.Count} followers");

            foreach (var item in followersCommentsAndLikes)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Sum()}");
            }
        }
    }
}
