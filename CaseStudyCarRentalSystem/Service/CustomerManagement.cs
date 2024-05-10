using CaseStudyCarRentalSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Service
{
    internal class CustomerManagement : ICustomerManagement
    {
        readonly ICarLeaseRepository _CustomerManagement;
        //constructor
        public CustomerManagement()
        {
            _CustomerManagement = new CarLeaseRepositoryImpl();
        }
        public void AddCustomer()
        {
            ListCustomers();
            Console.WriteLine("Enter customer details:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            Customer alreadyExists = _CustomerManagement.FindCustomerByEmail(email);

            Customer customer = new Customer(firstName, lastName, email, phoneNumber);

            int AddCustomerStatus = _CustomerManagement.AddCustomer(customer);
            if (AddCustomerStatus > 0)
            {
                Console.WriteLine("Customer Added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to Add Customer.");
            }
        }

        public void RemoveCustomer()
        {
            Console.Write("Enter the customer id: ");
            int customerID = int.Parse(Console.ReadLine());
            int RemoveCustomerStatus = _CustomerManagement.RemoveCustomer(customerID);
            if (RemoveCustomerStatus > 0)
            {
                Console.WriteLine("Customer removed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to remove Customer.");
            }
        }

        public void ListCustomers()
        {

            List<Customer> allCustomers = _CustomerManagement.ListCustomers();
            foreach (Customer item in allCustomers)
            {
                Console.WriteLine(item);

            }

        }

        public void FindCustomerById()
        {
            Console.Write("Enter the customerID id: ");
            int customerID = int.Parse(Console.ReadLine());
            Customer customer = _CustomerManagement.FindCustomerById(customerID);
            if (customer != null)
            {
                Console.WriteLine(customer);
            }
            else
            {
                Console.WriteLine("Please enter valid customer Id");
            }

        }
    }
}