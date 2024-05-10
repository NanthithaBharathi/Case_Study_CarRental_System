using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace CaseStudy.Service
{
    internal interface ICustomerManagement
    {
        void AddCustomer();
        void RemoveCustomer();
        void ListCustomers();
        void FindCustomerById();
    }
}