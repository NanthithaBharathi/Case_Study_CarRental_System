using CaseStudyCarRentalSystem.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace CaseStudy.Service
{
    internal class LeaseManagement : ILeaseManagement
    {
        readonly ICarLeaseRepository _LeaseManagement;
        //constructor
        public LeaseManagement()
        {
            _LeaseManagement = new CarLeaseRepositoryImpl();
        }


        public void CreateLease()
        {

            Console.WriteLine("Enter lease details:");
            Console.WriteLine("Enter Lease ID: ");
            int leaseId = int.Parse(Console.ReadLine());

            Console.Write("Customer ID: ");
            int customerId = int.Parse(Console.ReadLine());

            Console.Write("Car ID: ");
            int carId = int.Parse(Console.ReadLine());

            Console.Write("Start Date (YYYY-MM-DD): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("End Date (YYYY-MM-DD): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.Write("type : ");
            string type = Console.ReadLine();


            int CreateLeaseStatus = _LeaseManagement.CreateLease(leaseId, customerId, carId, startDate, endDate, type);
            if (CreateLeaseStatus == 1)
            {
                Console.WriteLine("Lease created Successfully");
            }
            else
            {
                Console.WriteLine("Lease not created");
            }

        }


        public void ReturnCar()
        {

            Console.Write("enter the lease id: ");
            int leaseID = int.Parse(Console.ReadLine());
            Lease lease = _LeaseManagement.ReturnCar(leaseID);
            if (lease != null)
            {
                Lease result = new Lease();
                Console.WriteLine("-------Car Details------");
                Console.WriteLine("Car Found successfully.");
                result.LeaseID = lease.LeaseID;
                result.VehicleID = lease.VehicleID;
                result.CustomerID = lease.CustomerID;
                result.StartDate = lease.StartDate;
                result.EndDate = lease.EndDate;
                result.Type = lease.Type;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Faild to get Car Details.");
            }

        }

        public List<Lease> ListActiveLeases()
        {
            List<Lease> allActiveLeases = _LeaseManagement.ListActiveLeases();
            if (allActiveLeases.Count == 0)
            {
                Console.WriteLine("No Active leases available");
            }
            return allActiveLeases;

        }

        public List<Lease> ListLeaseHistory()
        {
            List<Lease> allLease = _LeaseManagement.ListLeaseHistory();
            if (allLease.Count == 0)
            {
                Console.WriteLine("No Active leases available");
            }
            return allLease;
        }
    }
}