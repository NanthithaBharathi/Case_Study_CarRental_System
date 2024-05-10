using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace CaseStudyCarRentalSystem.Exception_Handling
{
    internal class CarNotFoundException : Exception
    {
        public CarNotFoundException(int CarID) : base($"Car with ID {CarID} not found in the database.") { }

    }
}