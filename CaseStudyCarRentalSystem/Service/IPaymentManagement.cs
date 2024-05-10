using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace CaseStudy.Service
{
    internal interface IPaymentManagement
    {
        void recordPayment();
        void totalRevenue();
    }
}