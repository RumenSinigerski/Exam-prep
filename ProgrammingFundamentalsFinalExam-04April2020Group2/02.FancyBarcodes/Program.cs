using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.FancyBarcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"^([@][#]+)(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])([@][#]+)$";

            Regex regex = new Regex(pattern);

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();

                Match match = regex.Match(input);

                if (match.Success)
                {
                    var barcode = match.Groups["barcode"].Value;

                    StringBuilder sb = new StringBuilder();

                    for (int j = 0; j < barcode.Length; j++)
                    {
                        if (Char.IsDigit(barcode[j]))
                        {
                            sb.Append(barcode[j]);
                        }
                    }

                    if (sb.Length > 0)
                    {
                        Console.WriteLine($"Product group: {sb.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: 00");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
