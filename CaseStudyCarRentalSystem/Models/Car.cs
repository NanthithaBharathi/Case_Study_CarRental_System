using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    public class Car
    {

        public int VehicleID { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal DailyRate { get; set; }
        public string Status { get; set; }
        public int PassengerCapacity { get; set; }
        public int EngineCapacity { get; set; }

        public Car(int vehicleID, string make, string model, int year, decimal dailyRate, string status, int passengerCapacity, int engineCapacity)
        {
            VehicleID = vehicleID;
            Make = make;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            Status = status;
            PassengerCapacity = passengerCapacity;
            EngineCapacity = engineCapacity;
        }

        public Car()
        {
        }


        public override string ToString()
        {
            return $"VehicleId: {VehicleID}\t Make: {Make}\t Model: {Model}\t Year: {Year}\t Daily Rate: {DailyRate}\t Status: {Status}\t Passenger Capacity: {PassengerCapacity}\t Engine Capacity: {EngineCapacity}";
        }
    }
}