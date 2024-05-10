using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    public class Lease
    {

        public int LeaseID { get; set; }
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; }


        public Lease(int leaseID, int vehicleID, int customerID, DateTime startDate, DateTime endDate, string type)
        {
            LeaseID = leaseID;
            VehicleID = vehicleID;
            CustomerID = customerID;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
        }
        public Lease() { }

        public override string ToString()
        {
            return $"leaseID::{LeaseID}\t CustomerId::{CustomerID}\t vehicleId::{VehicleID}\t StartDate::{StartDate}\t EndDate::{EndDate}\t type::{Type}\t ";
        }
    }
}