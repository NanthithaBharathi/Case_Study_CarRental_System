using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using CaseStudy;

//using System.Threading.Tasks;

namespace CaseStudyCarRentalSystem.Repository
{
    internal interface ICarLeaseRepository
    {
        // Car Management
        int AddCar(Car car);
        int RemoveCar(int carID);
        List<Car> ListAvailableCars();
        List<Car> ListRentedCars();
        Car FindCarById(int carID);

        // Customer Management
        int AddCustomer(Customer customer);
        int RemoveCustomer(int customerID);
        List<Customer> ListCustomers();
        Customer FindCustomerById(int customerID);
        Customer FindCustomerByEmail(string Email);

        // Lease Management
        int CreateLease(int leaseID, int customerID, int carID, DateTime startDate, DateTime endDate, string Type);
        Lease ReturnCar(int leaseID);
        List<Lease> ListActiveLeases();
        List<Lease> ListLeaseHistory();

        // Payment Handling
        void RecordPayment(Payment payment, decimal amount);
        void TotalRevenue(Payment payment, decimal amount);
    }
}