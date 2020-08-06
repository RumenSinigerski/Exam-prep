using System;
using System.Linq;
using System.Text;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = Console.ReadLine();

            var command = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("Reveal"))
            {
                if (command.Contains("InsertSpace"))
                {
                    message = InsertSpace(message, command);
                }
                else if (command.Contains("Reverse"))
                {
                    message = ReverseSubstringAndAddAtEnd(message, command);
                }
                else if (command.Contains("ChangeAll"))
                {
                    message = ChangeAllSubstrings(message, command);
                }

                command = Console.ReadLine().Split(":|:", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        static string InsertSpace(string msg, string[] command)
        {
            int index = int.Parse(command[1]);

            msg = msg.Insert(index, " ");
            Console.WriteLine(msg);
            return msg;
        }

        static string ReverseSubstringAndAddAtEnd(string msg, string[] command)
        {
            string text = command[1];
            int index = msg.IndexOf(text);
            StringBuilder sb = new StringBuilder();

            if (msg.Contains(text))
            {
                for (int i = text.Length + index - 1; i >= index; i--)
                {
                    sb.Append(msg[i]);
                }

                msg = msg.Substring(0, index) + msg.Substring(index + text.Length) + sb.ToString();
                Console.WriteLine(msg);
            }
            else
            {
                Console.WriteLine("error");
            }
            
            return msg;
        }

        static string ChangeAllSubstrings(string msg, string[] command)
        {
            string toReplace = command[1];
            string replacement = command[2];

            if (msg.Contains(toReplace))
            {
                msg = msg.Replace(toReplace, replacement);
            }
            Console.WriteLine(msg);
            return msg;
        }
    }
}
