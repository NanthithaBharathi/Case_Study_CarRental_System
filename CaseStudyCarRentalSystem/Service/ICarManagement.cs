using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Service
{
    internal interface ICarManagement
    {
        void AddCar();
        void RemoveCar();
        List<Car> ListAvailableCars();
        List<Car> ListRentedCars();
        void FindCarById();
    }
}