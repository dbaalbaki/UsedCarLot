using System;
using System.Collections.Generic;
namespace DevBuildLab_5._3
{
    class Car
    {
        public string Make;
        public string Model;
        public int Year;
        public decimal Price;
        public Car(string Cmake, string Cmodel, int Cyear, decimal Cprice)
        {
            Make = Cmake;
            Model = Cmodel;
            Year = Cyear;
            Price = Cprice;
        }
        public override string ToString()
        {
            return $"{Make},\t {Model},\t {Year},\t ${Price}";
        }
    }
    class UsedCar : Car
    {
        public double Mileage;
        public UsedCar(string Cmake, string Cmodel, int Cyear, decimal Cprice, double Cmileage) : base(Cmake, Cmodel, Cyear, Cprice)
        {
            Mileage = Cmileage;
        }
        public override string ToString()
        {
            return base.ToString() + $",\t (Used) {Mileage} miles";
        }
    }
    class CarLot
    {
        static public List<Car> carlot = new List<Car>();
        static public void AddCar(Car car)
        {
            carlot.Add(car);
        }
        static public void UserAddedCar()
        {
            Console.Write("Make: ");
            string make = Console.ReadLine();
            Console.Write("Model: ");
            string model = Console.ReadLine();
            Console.Write("Year: ");
            int year = Int32.Parse(Console.ReadLine());
            Console.Write("Price: ");
            decimal price = Int32.Parse(Console.ReadLine());
            Console.Write("Mileage: ");
            double mileage = Int32.Parse(Console.ReadLine());
            CarLot.AddCar(new UsedCar(make, model, year, price, mileage));
        }
        static public bool ListCars()
        {
            //Console.Clear();
            for (int i = 0; i < carlot.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {carlot[i]}");
            }
            Console.WriteLine($"{carlot.Count + 1} Add a Vechile");
            Console.WriteLine($"{carlot.Count + 2} Quit ");
            Console.Write("Select the car would you like to buy? ");
            int choice = Int32.Parse(Console.ReadLine());
            if (choice > 0 && choice < carlot.Count + 1)
            {
                Console.WriteLine($"\nYour choice was\n{ carlot[choice]}");
                Console.Write($"\nAre you sure you would like to buy this car? Please enter y or n: ");
                string buy = Console.ReadLine();
                if (buy == "y")
                {
                    Console.WriteLine("\nThe finanical department will be with you shortly. ");
                    CarLot.BuyCar(choice, carlot);
                }
                else
                {
                    Console.Clear();
                }
                return true;
            }
            else if (choice == carlot.Count + 1)
            {
                CarLot.UserAddedCar();
                return true;
            }
            else if (choice == carlot.Count + 2)
            {
                Console.WriteLine("Thank you! Have a wonderful great day!");
                return false;
            }
            else
            {
                return false;
            }
        }
        static public void BuyCar(int choice, List<Car> carlot)
        {
            carlot.Remove(carlot[choice - 1]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CarLot.AddCar(new Car("Ford", "Wrangler", 2021, 31000.99m));
            CarLot.AddCar(new Car("Ford", "Escape", 2017, 31999.90m));
            CarLot.AddCar(new Car("Chevy", "Sonic", 2017, 44989.95m));
            CarLot.AddCar(new UsedCar("Dodge", "Ram", 2016, 18000m, 33000));
            CarLot.AddCar(new UsedCar("Honda", "Civic ", 2015, 12795.50m, 35987));
            CarLot.AddCar(new UsedCar("Toyota", "Camry", 2009, 8400.48m, 180000));
            Console.WriteLine("Welcome to Grant Chirpus' Used Car Emporium!\n");
            bool cont = true;
            while (cont)
            {
                cont = CarLot.ListCars();
            }
        }
    }
}
