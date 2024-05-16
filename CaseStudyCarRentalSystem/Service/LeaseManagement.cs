using CaseStudyCarRentalSystem.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using CaseStudy.Service;
using System.Text;
using System.Threading.Tasks;

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

        readonly ICarLeaseRepository _CustomerManagement;
        //constructor


       // CustomerManagement _CustomerManagement = new CustomerManagement();
        public async void CreateLease()
        {
            Console.WriteLine("1 for Recording Previous Lease: ");
            Console.WriteLine("2 for Creating Active Lease: ");
            int Response = int.Parse(Console.ReadLine());
            if(Response == 1) 
            {
                Console.WriteLine("Enter lease details:");

                Console.Write("Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());

                Console.Write("Car ID: ");
                int carId = int.Parse(Console.ReadLine());

                DateTime Today = DateTime.Today;
                string formattedDate = Today.ToString("yyyy-MM-dd");


                Console.Write("Start Date (YYYY-MM-DD): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("End Date (YYYY-MM-DD): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                Console.Write("type : ");
                string type = Console.ReadLine();

                Customer customer = _LeaseManagement.FindCustomerById(customerId);

                if (customer == null)
                {
                    Console.WriteLine("Customer doesn't exist");
                    return;
                }

                Car car = _LeaseManagement.FindCarById(carId);

                if (car == null)
                {
                    Console.WriteLine("CarID doesn't exist");
                    return;
                }
                else
                {
                    if (car.Status != "available")
                    {
                        Console.WriteLine("Car is rented");
                        return;

                    }
                }
                if (endDate >= DateTime.Parse(formattedDate))
                {
                    Console.WriteLine("Invalid Date");
                    return;
                }

                if (startDate > endDate)
                {
                    Console.WriteLine("Invalid Start date or End date");
                    return;
                }


                int CreateLeaseStatus = _LeaseManagement.CreateLease(customerId, carId, startDate, endDate, type);
                if (CreateLeaseStatus == 1)
                {
                    Console.WriteLine("Lease created Successfully");
                }
                else
                {
                    Console.WriteLine("Lease not created");
                }

            }

            if (Response == 2)
            {
                Console.WriteLine("Enter lease details:");

                Console.Write("Customer ID: ");
                int customerId = int.Parse(Console.ReadLine());

                Console.Write("Car ID: ");
                int carId = int.Parse(Console.ReadLine());

                DateTime Today = DateTime.Today.AddDays(1);
                string formattedDate = Today.ToString("yyyy-MM-dd");


                Console.Write("Start Date (YYYY-MM-DD): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());

                Console.Write("End Date (YYYY-MM-DD): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());

                Console.Write("type : ");
                string type = Console.ReadLine();

                Customer customer = _LeaseManagement.FindCustomerById(customerId);

                if (customer == null)
                {
                    Console.WriteLine("Customer doesn't exist");
                    return;
                }

                Car car = _LeaseManagement.FindCarById(carId);

                if (car == null)
                {
                    Console.WriteLine("CarID doesn't exist");
                    return;
                }
                else
                {
                    if (car.Status != "available")
                    {
                        Console.WriteLine("Car is rented");
                        return;

                    }
                    
                }
                if (startDate != DateTime.Parse(formattedDate))
                {
                    Console.WriteLine("Lease StartDate should be Tomorrow");
                    return;
                }

                if (endDate < startDate)
                {
                    Console.WriteLine("Invalid Start date or End date");
                    return;
                }


                int CreateLeaseStatus = _LeaseManagement.CreateLease(customerId, carId, startDate, endDate, type);

                if (CreateLeaseStatus == 1)
                {
                    Console.WriteLine("Lease created Successfully");
                    await Task.Delay(1000);
                    int LeaseStatus = _LeaseManagement.UpdateCar(carId);
                    if (LeaseStatus > 0)
                    {
                        Console.WriteLine(" Car status updated successfully");
                    }

                }
                else
                {
                    Console.WriteLine("Lease not created");

                }
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