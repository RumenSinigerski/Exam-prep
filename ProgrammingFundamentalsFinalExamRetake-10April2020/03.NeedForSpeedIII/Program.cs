using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeedIII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<int>> carMileageFuel = new Dictionary<string, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);

                string car = input[0];
                int mileage = int.Parse(input[1]);
                int fuel = int.Parse(input[2]);

                if (!carMileageFuel.ContainsKey(car))
                {
                    carMileageFuel.Add(car, new List<int>() {mileage, fuel});
                }
            }

            var command = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);

            while (!command.Contains("Stop"))
            {
                if (command.Contains("Drive"))
                {
                    string car = command[1];
                    int distance = int.Parse(command[2]);
                    int fuelNeeded = int.Parse(command[3]);

                    if (fuelNeeded > carMileageFuel[car][1])
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                    else
                    {
                        carMileageFuel[car][0] += distance;
                        carMileageFuel[car][1] -= fuelNeeded;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuelNeeded} liters of fuel consumed.");

                        if (carMileageFuel[car][0] >= 100000)
                        {
                            carMileageFuel.Remove(car);

                            Console.WriteLine($"Time to sell the {car}!");
                        }
                    }
                }
                else if (command.Contains("Refuel"))
                {
                    string car = command[1];
                    int fuel = int.Parse(command[2]);

                    if (75 - carMileageFuel[car][1] >= fuel)
                    {
                        carMileageFuel[car][1] += fuel;
                        Console.WriteLine($"{car} refueled with {fuel} liters");
                    }
                    else
                    {                       
                        Console.WriteLine($"{car} refueled with {75 - carMileageFuel[car][1]} liters");
                        carMileageFuel[car][1] = 75;
                    }
                }
                else if (command.Contains("Revert"))
                {
                    string car = command[1];
                    int mileage = int.Parse(command[2]);

                    if (carMileageFuel[car][0] - mileage >= 10000)
                    {
                        carMileageFuel[car][0] -= mileage;
                        Console.WriteLine($"{car} mileage decreased by {mileage} kilometers");
                    }
                    else
                    {
                        carMileageFuel[car][0] = 10000;
                    }
                }


                command = Console.ReadLine().Split(" : ", StringSplitOptions.RemoveEmptyEntries);
            }

            carMileageFuel = carMileageFuel.OrderByDescending(v => v.Value[0]).ThenBy(k => k.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in carMileageFuel)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value[0]} kms, Fuel in the tank: {item.Value[1]} lt.");
            }
        }
    }
}
