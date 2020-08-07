using System;
using System.Linq;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            var password = Console.ReadLine();

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("Done"))
            {
                if (command.Contains("TakeOdd"))
                {
                    password = TakeOddSymbols(password);
                }
                else if (command.Contains("Cut"))
                {
                    password = CutSymbols(password, command);
                }
                else if (command.Contains("Substitute"))
                {
                    password = ReplaceSubstring(password, command);
                }

                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"Your password is: { password}");
        }

        static string TakeOddSymbols(string pass)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i < pass.Length; i+=2)
            {
                sb.Append(pass[i]);
            }

            Console.WriteLine(sb.ToString());

            return sb.ToString();
        }

        static string CutSymbols(string pass, string[] command)
        {
            int index = int.Parse(command[1]);
            int lenght = int.Parse(command[2]);

            pass = pass.Substring(0, index) + pass.Substring(index + lenght);

            Console.WriteLine(pass);

            return pass;
        }

        static string ReplaceSubstring(string pass, string[] command)
        {
            string toReplace = command[1];
            string replacement = command[2];

            if (pass.Contains(toReplace))
            {
                pass = pass.Replace(toReplace, replacement);
                Console.WriteLine(pass);
            }
            else
            {
                Console.WriteLine("Nothing to replace!");
            }

            return pass;
        }
    }
}
