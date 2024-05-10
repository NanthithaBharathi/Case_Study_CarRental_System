using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace CaseStudyCarRentalSystem.Exception_Handling
{
    internal class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(int CustomerID) : base($"Customer Id {CustomerID} not found")
        {
        }
    }
}