using CaseStudy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
//using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy
{
    internal class Casestudyapp
    {
        readonly ICarManagement _CarManagement;
        readonly ICustomerManagement _CustomerManagement;
        readonly ILeaseManagement _LeaseManagement;
        readonly IPaymentManagement _PaymentManagement;
        public Casestudyapp()
        {
            _CarManagement = new CarManagement();
            _CustomerManagement = new CustomerManagement();
            _LeaseManagement = new LeaseManagement();
            _PaymentManagement = new PaymentManagement();

        }

        public ICustomerManagement Get_CustomerManagement()
        {
            return _CustomerManagement;
        }


        //constructor

        public void HandleMainMenu()
        {

            while (true)
            {
            mainmenu:
                Console.WriteLine("-------Main Menu-------");
                Console.WriteLine("1.Customer Management \n2.Car Management \n3.Lease Management \n4.Payment Handling \n5.Exit");
                Console.WriteLine("Enter your choice:");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            while (true)
                            {

                                Console.WriteLine("------Customer Management------");
                                Console.WriteLine("1.Add Customer \n2.Remove Customer \n3.List Customers \n4.Find Customer By Id \n5.Main Menu");
                                Console.WriteLine("Enter your choice:");
                                int choice1 = int.Parse(Console.ReadLine());
                                switch (choice1)
                                {
                                    case 1:
                                        {

                                            _CustomerManagement.AddCustomer();
                                            break;
                                        }
                                    case 2:
                                        {
                                            _CustomerManagement.RemoveCustomer();
                                            break;
                                        }
                                    case 3:
                                        {
                                            _CustomerManagement.ListCustomers();

                                            break;
                                        }
                                    case 4:
                                        {
                                            _CustomerManagement.FindCustomerById();

                                            break;
                                        }
                                    case 5:
                                        {
                                            goto mainmenu;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("INVALID CHOICE");
                                            break;
                                        }
                                }
                            }
                        }
                    case 2:
                        {
                            while (true)
                            {

                                Console.WriteLine("------Car Management------");
                                Console.WriteLine("Enter your choice:");
                                Console.WriteLine("1.Add Car \n2.Remove Car \n3.List Available Cars \n4.List Rented Cars \n5.Find Car By Id \n6.Main Menu");
                                int choice3 = int.Parse(Console.ReadLine());
                                switch (choice3)
                                {
                                    case 1:
                                        {

                                            _CarManagement.AddCar();
                                            break;
                                        }
                                    case 2:
                                        {

                                            _CarManagement.RemoveCar();

                                            break;
                                        }
                                    case 3:
                                        {

                                            List<Car> allVehicles = _CarManagement.ListAvailableCars();

                                            foreach (Car item in allVehicles)
                                            {
                                                Console.WriteLine(item);

                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            List<Car> cars = _CarManagement.ListRentedCars();
                                            foreach (var car in cars)
                                            {
                                                Console.WriteLine(car);
                                            }
                                            break;
                                        }
                                    case 5:
                                        {
                                            _CarManagement.FindCarById();
                                            break;
                                        }
                                    case 6:
                                        {
                                            goto mainmenu;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("INVALID CHOICE");
                                            break;
                                        }
                                }
                            }
                        }
                    case 3:
                        {
                            while (true)
                            {
                                Console.WriteLine("-------------Lease Management--------------");
                                Console.WriteLine("Enter your choice:");
                                Console.WriteLine("1.Create Lease \n2.List Active Leases \n3.List Lease History \n4.Main Menu");
                                int choice4 = int.Parse(Console.ReadLine());
                                switch (choice4)
                                {
                                    case 1:
                                        {

                                            _LeaseManagement.CreateLease();

                                            break;
                                        }
                                    case 2:
                                        {
                                            List<Lease> leases = _LeaseManagement.ListActiveLeases();
                                            foreach (var lease in leases)
                                            {
                                                Console.WriteLine(lease);
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            List<Lease> leases = _LeaseManagement.ListLeaseHistory();
                                            foreach (var lease in leases)
                                            {
                                                Console.WriteLine(lease);
                                            }
                                            break;
                                        }
                                    case 4:
                                        {
                                            goto mainmenu;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("INVALID CHOICE");

                                            break;
                                        }
                                }
                            }
                        }
                    case 4:
                        {
                            while (true)
                            {
                                Console.WriteLine("---------Payment Handling-----------");
                                Console.WriteLine("Enter your choice:");
                                Console.WriteLine("1.Record Payment \n2.Main Menu");
                                int choice5 = int.Parse(Console.ReadLine());
                                switch (choice5)
                                {
                                    case 1:
                                        {
                                            _PaymentManagement.recordPayment();
                                            break;
                                        }
                                    case 2:
                                        {
                                            goto mainmenu;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("INVALID CHOICE");
                                            break;
                                        }
                                }
                            }
                        }
                    case 5:
                        {
                            Console.WriteLine("Exit");
                            Environment.Exit(0);
                            break;
                        }

                }
            }

        }
    }
}