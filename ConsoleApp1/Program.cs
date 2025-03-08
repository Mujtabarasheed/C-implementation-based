using System;

namespace VehicleSystem
{
    // 1. Define a Base Class: Vehicle
    public abstract class Vehicle
    {
        // Common properties with appropriate access modifiers
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        protected int Speed { get; set; } // Speed is protected to allow access in derived classes

        // Constructor to initialize common properties
        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
            Speed = 0; // Initialize speed to 0
        }

        // Abstract methods that must be implemented by derived classes
        public abstract void StartEngine();
        public abstract void StopEngine();

        // Optional: A method to display vehicle details
        public void DisplayDetails()
        {
            Console.WriteLine($"Make: {Make}, Model: {Model}, Year: {Year}, Current Speed: {Speed} km/h");
        }
    }

    // 3. Create an Interface: IMaintainable
    public interface IMaintainable
    {
        void PerformMaintenance();
        void Refuel();
    }

    // 2. Implement Derived Classes: Car
    public class Car : Vehicle, IMaintainable
    {
        // Additional property specific to Car
        public int NumberOfDoors { get; set; }

        // Constructor
        public Car(string make, string model, int year, int numberOfDoors) : base(make, model, year)
        {
            NumberOfDoors = numberOfDoors;
        }

        // Override StartEngine method
        public override void StartEngine()
        {
            Console.WriteLine("Car engine started.");
            Speed = 0; // Reset speed when engine starts
        }

        // Override StopEngine method
        public override void StopEngine()
        {
            Console.WriteLine("Car engine stopped.");
            Speed = 0; // Reset speed when engine stops
        }

        // Implement PerformMaintenance method from IMaintainable
        public void PerformMaintenance()
        {
            Console.WriteLine("Performing maintenance on the car: Checking oil, tires, and brakes.");
        }

        // Implement Refuel method from IMaintainable
        public void Refuel()
        {
            Console.WriteLine("Refueling the car with petrol.");
        }
    }

    // 2. Implement Derived Classes: Truck
    public class Truck : Vehicle, IMaintainable
    {
        // Additional property specific to Truck
        public double CargoCapacity { get; set; } // in tons

        // Constructor
        public Truck(string make, string model, int year, double cargoCapacity) : base(make, model, year)
        {
            CargoCapacity = cargoCapacity;
        }

        // Override StartEngine method
        public override void StartEngine()
        {
            Console.WriteLine("Truck engine started.");
            Speed = 0; // Reset speed when engine starts
        }

        // Override StopEngine method
        public override void StopEngine()
        {
            Console.WriteLine("Truck engine stopped.");
            Speed = 0; // Reset speed when engine stops
        }

        // Implement PerformMaintenance method from IMaintainable
        public void PerformMaintenance()
        {
            Console.WriteLine("Performing maintenance on the truck: Checking engine, brakes, and cargo straps.");
        }

        // Implement Refuel method from IMaintainable
        public void Refuel()
        {
            Console.WriteLine("Refueling the truck with diesel.");
        }
    }

    // Main Program
    internal class Program
    {
        static void Main(string[] args)
        {
            // 4. Instantiate Objects and Demonstrate Functionality

            // Create a Car object
            Car myCar = new Car("Toyota", "Corolla", 2022, 4);
            Console.WriteLine("Car Details:");
            myCar.DisplayDetails(); // Display car details
            myCar.StartEngine();    // Start the car engine
            myCar.PerformMaintenance(); // Perform maintenance
            myCar.Refuel();        // Refuel the car
            myCar.StopEngine();    // Stop the car engine
            Console.WriteLine();

            // Create a Truck object
            Truck myTruck = new Truck("Ford", "F-150", 2020, 2.5);
            Console.WriteLine("Truck Details:");
            myTruck.DisplayDetails(); // Display truck details
            myTruck.StartEngine();    // Start the truck engine
            myTruck.PerformMaintenance(); // Perform maintenance
            myTruck.Refuel();        // Refuel the truck
            myTruck.StopEngine();    // Stop the truck engine
            Console.WriteLine();

            // 4. Demonstrate Polymorphism
            Console.WriteLine("Demonstrating Polymorphism:");
            Vehicle vehicle1 = myCar;   // Reference to Car object as Vehicle
            Vehicle vehicle2 = myTruck; // Reference to Truck object as Vehicle

            vehicle1.StartEngine(); // Calls Car's StartEngine method
            vehicle2.StartEngine(); // Calls Truck's StartEngine method
        }
    }
}