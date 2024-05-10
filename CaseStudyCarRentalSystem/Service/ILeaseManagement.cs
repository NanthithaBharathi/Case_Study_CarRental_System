using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace CaseStudy.Service
{
    internal interface ILeaseManagement
    {
        void CreateLease();
        void ReturnCar();
        List<Lease> ListActiveLeases();
        List<Lease> ListLeaseHistory();
    }
}