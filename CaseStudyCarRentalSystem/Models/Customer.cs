using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer(int customerID, string firstName, string lastName, string email, string phoneNumber)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Customer()
        {
        }
        public Customer(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public override string ToString()
        {
            return $"CustomerID::{CustomerID}\t FirstName::{FirstName}\t LastName::{LastName}\t Email::{Email}\t PhoneNumber::{PhoneNumber}\t";
        }
    }
}