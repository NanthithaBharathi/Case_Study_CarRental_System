﻿
using CaseStudyCarRentalSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace CaseStudy.Service
{
    internal class CarManagement : ICarManagement

    {

        readonly ICarLeaseRepository _CarManagement;
        //constructor
        public CarManagement()
        {
            _CarManagement = new CarLeaseRepositoryImpl();
        }
        public void AddCar()
        {
            // Create an instance of CarManager
            CarManagement carManager = new CarManagement();

            

            Console.WriteLine("Enter Car details:");
            

            Console.Write("Make: ");
            string make = Console.ReadLine();

            Console.Write("Model: ");
            string model = Console.ReadLine();

            Console.Write("Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Daily Rate: ");
            decimal dailyRate = decimal.Parse(Console.ReadLine());

            Console.Write("Status: ");
            string status = Console.ReadLine();

            Console.Write("Passenger Capacity: ");
            int passengerCapacity = int.Parse(Console.ReadLine());

            Console.Write("Engine Capacity: ");
            int engineCapacity = int.Parse(Console.ReadLine());

            Car car = new Car( make, model, year, dailyRate, status, passengerCapacity, engineCapacity);

            int AddCarStatus = _CarManagement.AddCar(car);
            if (AddCarStatus > 0)
            {
                Console.WriteLine("Car Added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to Add Car.");
            }

        }

        public void RemoveCar()
        {
            Console.Write("Enter the car id: ");
            int carID = int.Parse(Console.ReadLine());
            int RemoveCarStatus = _CarManagement.RemoveCar(carID);
            if (RemoveCarStatus > 0)
            {
                Console.WriteLine("Car removed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to remove Car.");
            }
        }
        public List<Car> ListAvailableCars()
        {

            List<Car> allVehicles = _CarManagement.ListAvailableCars();
            if (allVehicles.Count == 0)
            {
                Console.WriteLine("No cars available");
            }
            return allVehicles;
        }



        public List<Car> ListRentedCars()
        {
            List<Car> cars = _CarManagement.ListRentedCars();
            if (cars.Count == 0)
            {
                Console.WriteLine("No Rented Cars Available");
            }
            return cars;

        }
        public void FindCarById()
        {

            Console.Write("Enter the Car ID: ");
            Car car = null;
            try
            {

                int carID = int.Parse(Console.ReadLine());
                car = _CarManagement.FindCarById(carID);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input, integers are only allowed");
            }
            
            if (car != null)
            {
                Console.WriteLine("-------Car Details------");
                Console.WriteLine("Car Found successfully.");
                Console.WriteLine(car);
            }
            else
            {
                Console.WriteLine("Failed to get Car.");
            }


        }
    }
}