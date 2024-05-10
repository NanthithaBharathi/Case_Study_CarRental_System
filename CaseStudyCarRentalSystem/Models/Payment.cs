using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    class Payment
    {
        public int PaymentID { get; set; }
        public int LeaseID { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }

        public Payment(int paymentID, int leaseID, DateTime paymentDate, decimal amount)
        {
            PaymentID = paymentID;
            LeaseID = leaseID;
            PaymentDate = paymentDate;
            Amount = amount;
        }

        public Payment()
        {
        }

        public void RecordPayment(Payment payment, decimal amount)
        {

            Console.WriteLine($"Recording payment of {amount} for the Date {payment.PaymentDate}");
        }

        public override string ToString()
        {
            return $"PaymentID::{PaymentID}\t LeaseID::{LeaseID}\t  PaymentDate::{PaymentDate}\t Amount::{Amount}";
        }
    }
}