using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudyCarRentalSystem.Exception_Handling
{
    internal class LeaseNotFoundException : Exception
    {
        public LeaseNotFoundException(int LeaseID) : base($"Lease with ID {LeaseID} not found in the database.") { }

    }
}