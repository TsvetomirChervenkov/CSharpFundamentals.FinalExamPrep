using System;
using System.Collections.Generic;

namespace T23.Need_for_Speed_III
{
    class Car
    {
        public Car(string name, double miles, double fuel)
        {
            this.Name = name;
            this.Miles = miles;
            this.Fuel = fuel;
        }
        public string Name { get; set; }
        public double Miles { get; set; }
        public double Fuel { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfcars = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            AddCarsToList(numOfcars, cars);

            string data = string.Empty;

            while ((data = Console.ReadLine()) != "Stop") 
            {
                string[] info = data.Split(" : ", StringSplitOptions.RemoveEmptyEntries);
                string action = info[0];
                if (action == "Drive")
                {
                    string model = info[1];
                    double distance = double.Parse(info[2]);
                    double fuel = double.Parse(info[3]);
                    if (cars[model].Fuel < fuel)
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                        continue;
                    }
                    cars[model].Fuel -= fuel;
                    cars[model].Miles += distance;
                    if (cars[model].Miles >= 100000)
                    {
                        Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        Console.WriteLine($"Time to sell the {model}!");
                        cars.Remove(model);
                        continue;
                    }
                    Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                }
                else if (action == "Refuel")
                {
                    string model = info[1];
                    double fuel = double.Parse(info[2]);
                    if (cars[model].Fuel+fuel >= 75)
                    {
                        
                        Console.WriteLine($"{model} refueled with {75-cars[model].Fuel} liters");
                        cars[model].Fuel = 75;
                        continue;
                    }
                    cars[model].Fuel += fuel;
                    Console.WriteLine($"{model} refueled with {fuel} liters");
                }
                else if (action == "Revert")
                {
                    string model = info[1];
                    double distance = double.Parse(info[2]);
                    if (cars[model].Miles-distance < 10000)
                    {
                        cars[model].Miles = 10000;
                        continue;
                    }
                    cars[model].Miles -= distance;
                    Console.WriteLine($"{model} mileage decreased by {distance} kilometers");
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Value.Name} -> Mileage: {car.Value.Miles} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
            
        }
        static void AddCarsToList(int numOfcars, Dictionary<string, Car> cars)
        {
            for (int i = 0; i < numOfcars; i++)
            {
                string[] data = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);
                string name = data[0];
                double miles = double.Parse(data[1]);
                double fuel = double.Parse(data[2]);

                Car newCar = new Car(name, miles, fuel);
                cars.Add(name, newCar);
            }
        }
    }
}
