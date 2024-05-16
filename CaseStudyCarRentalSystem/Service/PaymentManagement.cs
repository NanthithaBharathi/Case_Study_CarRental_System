using CaseStudyCarRentalSystem.Repository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace CaseStudy.Service
{
    internal class PaymentManagement : IPaymentManagement
    {
        readonly ICarLeaseRepository _PaymentManagement;
        //constructor
        public PaymentManagement()
        {
            _PaymentManagement = new CarLeaseRepositoryImpl();
        }
        public void recordPayment()
        {
            Console.WriteLine("Enter payment details:");
           

            Console.WriteLine("Enter Lease ID:");
            int leaseID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Payment Date (YYYY-MM-DD):");
            DateTime paymentDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Payment Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            List<Lease> activeLease = _PaymentManagement.ListActiveLeases();

            //Create Lease object using user input
           Payment payment = new Payment(leaseID, paymentDate, amount);


           PaymentManagement.RecordPayment(payment, amount);
            

            Console.WriteLine("Payment created successfully");
        }
        public void totalRevenue()
        {
            Console.WriteLine("Total revenue");
        }
    }
}