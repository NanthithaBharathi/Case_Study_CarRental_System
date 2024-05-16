using CaseStudyCarRentalSystem.Exception_Handling;
using CaseStudy.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
//using MySql.Data.MySqlClient;
using CaseStudy;

//using System.Threading.Tasks;

namespace CaseStudyCarRentalSystem.Repository
{
    public class CarLeaseRepositoryImpl : ICarLeaseRepository
    {
        readonly SqlConnection sqlConnection = null;
        readonly SqlCommand cmd = null;
        //private const string ConnectionString = "Server = localhost; Database = CarRentalSystemDB ; Uid = root ; Password = root;";
        public CarLeaseRepositoryImpl()
        {
            sqlConnection = new SqlConnection("Server=DESKTOP-1AQKMLP\\SQLEXPRESS;DataBase=CRS1;Trusted_Connection=True");
            cmd = new SqlCommand();
        }

        private List<Car> cars = new List<Car>();
        private List<Customer> customers = new List<Customer>();
        private List<Lease> leases = new List<Lease>();

        int ICarLeaseRepository.AddCar(Car car)
        {
            cmd.CommandText = "INSERT INTO VehicleTable ( make, model, year, dailyRate, status, passengerCapacity, engineCapacity) VALUES (@make, @model, @year, @dailyRate, @status, @passengerCapacity, @engineCapacity)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@make", car.Make);
            cmd.Parameters.AddWithValue("@model", car.Model);
            cmd.Parameters.AddWithValue("@year", car.Year);
            cmd.Parameters.AddWithValue("@dailyRate", car.DailyRate);
            cmd.Parameters.AddWithValue("@status", car.Status);
            cmd.Parameters.AddWithValue("@passengerCapacity", car.PassengerCapacity);
            cmd.Parameters.AddWithValue("@engineCapacity", car.EngineCapacity);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int createCarStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return createCarStatus;

        }

        int ICarLeaseRepository.UpdateCar(int CarID)
        {
            cmd.CommandText = "UPDATE VehicleTable SET status = @status WHERE vehicleID = @CarID";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CarID", CarID);
            cmd.Parameters.AddWithValue("@status","notAvailable");
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int createCarStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return createCarStatus;



        }

        int ICarLeaseRepository.RemoveCar(int carID)
        {
            int RemoveCarStatus = 0;

            cmd.CommandText = "DELETE FROM VehicleTable WHERE vehicleID = @VehicleId";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@VehicleId", carID);

            cmd.Connection = sqlConnection;
            try
            {
                sqlConnection.Open();
                RemoveCarStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);

            }

            return RemoveCarStatus;

        }


        List<Car> ICarLeaseRepository.ListAvailableCars()
        {
            Console.WriteLine("-------List of available Cars------");
            List<Car> cars = new List<Car>();
            cmd.CommandText = "SELECT * FROM VehicleTable WHERE status='Available'";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                {
                    Car car = new Car();
                    car.VehicleID = (int)reader["vehicleId"];
                    car.Make = (string)reader["make"];
                    car.Model = (string)reader["model"];
                    car.Year = (int)reader["year"];
                    car.Status = (string)reader["status"];
                    car.DailyRate = (decimal)reader["dailyrate"];
                    car.PassengerCapacity = (int)reader["passengerCapacity"];
                    car.EngineCapacity = (int)reader["engineCapacity"];

                    cars.Add(car);
                }
            }
            sqlConnection.Close();
            return cars;
        }

        List<Car> ICarLeaseRepository.ListRentedCars()
        {
            Console.WriteLine("-------List of Rented Cars------");
            List<Car> Cars = new List<Car>();
            cmd.CommandText = "SELECT * FROM VehicleTable WHERE status='notAvailable'";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                {
                    Car car = new Car();
                    car.VehicleID = (int)reader["vehicleID"];
                    car.Make = (string)reader["make"];
                    car.Model = (string)reader["model"];
                    car.Year = (int)reader["year"];
                    car.DailyRate = (decimal)reader["dailyRate"];
                    car.Status = (string)reader["status"];
                    car.PassengerCapacity = (int)reader["passengerCapacity"];
                    car.EngineCapacity = (int)reader["engineCapacity"];

                    Cars.Add(car);
                }
            }
            sqlConnection.Close();
            return Cars;

        }

        Car ICarLeaseRepository.FindCarById(int carID)
        {
            Car car = new Car();

            try
            {
                string sqlQuery = "SELECT * FROM VehicleTable WHERE vehicleID=@VehicleID";

                using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
                {
                    command.Parameters.AddWithValue("@VehicleID", carID);

                    sqlConnection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            car.VehicleID = (int)reader["vehicleID"];
                            car.Make = (string)reader["make"];
                            car.Model = (string)reader["model"];
                            car.Year = (int)reader["year"];
                            car.DailyRate = (decimal)reader["dailyRate"];
                            car.Status = (string)reader["status"];
                            car.PassengerCapacity = (int)reader["passengerCapacity"];
                            car.EngineCapacity = (int)reader["engineCapacity"];
                        }
                        else
                        {
                            // Throw an exception or return null, depending on your preference
                            //throw new CarNotFoundException("Car not found with ID: " + carID);
                            // Alternatively, you can return null here and handle it appropriately in the calling code.
                            // return null;
                            car = null;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any other exceptions here
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return car;

        }




        int ICarLeaseRepository.AddCustomer(Customer customer)
        {
            cmd.CommandText = "INSERT INTO CustomersTable ( FirstName, LastName, Email, PhoneNumber) VALUES ( @FirstName, @LastName, @Email, @PhoneNumber)";

            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int createCustomerStatus = cmd.ExecuteNonQuery();
            sqlConnection.Close();
            return createCustomerStatus;
        }

        int ICarLeaseRepository.RemoveCustomer(int customerID)
        {
            int RemoveCustomerIDStatus = 0;

            cmd.CommandText = "DELETE FROM CustomersTable WHERE customerID = @customerID";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@customerID", customerID);

            cmd.Connection = sqlConnection;
            try
            {
                sqlConnection.Open();
                RemoveCustomerIDStatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);

            }

            return RemoveCustomerIDStatus;
        }

        List<Customer> ICarLeaseRepository.ListCustomers()
        {
            Console.WriteLine("-------List of available customers------");
            List<Customer> customers = new List<Customer>();
            cmd.CommandText = "SELECT * FROM CustomersTable";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                Customer customer = new Customer();
                customer.CustomerID = (int)reader["customerID"];
                customer.FirstName = (string)reader["firstName"];
                customer.LastName = (string)reader["lastName"];
                customer.Email = (string)reader["email"];
                customer.PhoneNumber = (string)reader["phoneNumber"];
                customers.Add(customer);
            }

            sqlConnection.Close();
            return customers;
        }

        Customer ICarLeaseRepository.FindCustomerById(int customerID)
        {
            Customer customerNull = null;

            {
                string sqlQuery = "SELECT * FROM CustomersTable WHERE customerID = @customerID";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@customerID", customerID);

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerID = (int)reader["customerID"];
                                customer.FirstName = (string)reader["firstName"];
                                customer.LastName = (string)reader["lastName"];
                                customer.Email = (string)reader["email"];
                                customer.PhoneNumber = (string)reader["phoneNumber"];
                                sqlConnection.Close();
                                return customer;

                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error finding customer: {ex.Message}");
                    }
                }
            }
            sqlConnection.Close();
            return customerNull;
        }

        Customer ICarLeaseRepository.FindCustomerByEmail(string email)
        {
            Customer customerNull = null;

            {
                string sqlQuery = "SELECT * FROM CustomersTable WHERE email = @email";

                using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConnection))
                {
                    cmd.Parameters.AddWithValue("@email", email);

                    try
                    {
                        sqlConnection.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Customer customer = new Customer();
                                customer.CustomerID = (int)reader["customerID"];
                                customer.FirstName = (string)reader["firstName"];
                                customer.LastName = (string)reader["lastName"];
                                customer.Email = (string)reader["email"];
                                customer.PhoneNumber = (string)reader["phoneNumber"];
                                sqlConnection.Close();
                                return customer;

                            }

                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Error finding customer: {ex.Message}");
                    }
                }
            }
            sqlConnection.Close();
            return customerNull;
        }


        int ICarLeaseRepository.CreateLease( int customerID, int carID, DateTime startDate, DateTime endDate, string type)
        {

            int createLeaseStatus = 0;
            try
            {
                if (((ICarLeaseRepository)this).FindCustomerById(customerID) != null)
                {
                    if (((ICarLeaseRepository)this).FindCarById(carID) != null)
                    {
                        cmd.CommandText = "INSERT INTO LeaseTable(customerID, vehicleID, startDate, endDate, type) VALUES ( @customerID, @carID, @startDate, @endDate, @type )";

                        cmd.Parameters.Clear();
                       
                        cmd.Parameters.AddWithValue("@customerID", customerID);
                        cmd.Parameters.AddWithValue("@carID", carID);
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);
                        cmd.Parameters.AddWithValue("@type", type);

                        cmd.Connection = sqlConnection;

                        sqlConnection.Open();

                        createLeaseStatus = cmd.ExecuteNonQuery();
                        sqlConnection.Close();
                        return createLeaseStatus;

                    }
                    else
                    {
                        Console.WriteLine("Please Enter a valid Car Id");
                    }
                }
                else
                {
                    Console.WriteLine("Please Enter a valid Customer Id");
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);

            }
            sqlConnection.Close();
            return createLeaseStatus;

        }

        Lease ICarLeaseRepository.ReturnCar(int leaseID)
        {
            Lease lease = null;

            try
            {
                string sqlQuery = "SELECT * FROM LeaseTable WHERE leaseID=@leaseID";

                using (SqlCommand command = new SqlCommand(sqlQuery, sqlConnection))
                {
                    command.Parameters.AddWithValue("@leaseID", leaseID);

                    sqlConnection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lease = new Lease
                            {
                                LeaseID = (int)reader["leaseID"],
                                VehicleID = (int)reader["vehicleID"],
                                CustomerID = (int)reader["customerID"],
                                StartDate = (DateTime)reader["startDate"],
                                EndDate = (DateTime)reader["endDate"],
                                Type = (string)reader["type"],

                            };
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine($"An error occurred while finding car: {ex.Message}");
            }
            sqlConnection.Close();
            return lease;
        } 

        List<Lease> ICarLeaseRepository.ListActiveLeases()
        {
            Console.WriteLine("-------List of Active Leases------");
            List<Lease> leases = new List<Lease>();
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT * FROM LeaseTable WHERE endDate >= GETDATE()";
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Lease lease = new Lease();
                            lease.LeaseID = (int)reader["leaseID"];
                            lease.VehicleID = (int)reader["vehicleID"];
                            lease.CustomerID = (int)reader["customerID"];
                            lease.StartDate = (DateTime)reader["startDate"];
                            lease.EndDate = (DateTime)reader["endDate"];
                            lease.Type = (string)reader["type"];
                            leases.Add(lease);
                        }
                      
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                Console.WriteLine($"Error: {ex.Message}");
            }
            sqlConnection.Close();
            return leases;


        }

        List<Lease> ICarLeaseRepository.ListLeaseHistory()
        {
            Console.WriteLine("-------List of Leases------");
            List<Lease> leases = new List<Lease>();
            cmd.CommandText = "SELECT * FROM LeaseTable";
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {

                Lease lease = new Lease();
                lease.LeaseID = (int)reader["leaseID"];
                lease.VehicleID = (int)reader["vehicleID"];
                lease.CustomerID = (int)reader["customerID"];
                lease.StartDate = (DateTime)reader["startDate"];
                lease.EndDate = (DateTime)reader["endDate"];
                lease.Type = (string)reader["type"];
                leases.Add(lease);



            }
            sqlConnection.Close();
            return leases;
        }

        void ICarLeaseRepository.RecordPayment(Payment payment, decimal amount)
        {
            int createpaymentStatus = 0;
            try
            {
                // Insert payment record into the Payment table
                cmd.CommandText = "INSERT INTO PaymentTable (leaseID, paymentDate, amount) VALUES (@LeaseID, @PaymentDate, @Amount)";
                cmd.Parameters.AddWithValue("@LeaseID", payment.LeaseID);
                cmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@Amount", amount);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                createpaymentStatus = cmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                Console.WriteLine("Error recording payment: " + e.Message);
            }
        }

        void ICarLeaseRepository.TotalRevenue(Payment payment, decimal amount)
        {
            int createpaymentStatus = 0;
            try
            {
                // Insert payment record into the Payment table
                cmd.CommandText = "SELECT SUM(Amount) AS TotalRevenue FROM PaymentTable";
                

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                createpaymentStatus = cmd.ExecuteNonQuery();
                Console.WriteLine("Total Revenue: " + amount);

            }
            catch (SqlException e)
            {
                Console.WriteLine("Error recording payment: " + e.Message);
            }
        }

        public bool AddCar()
        {
            throw new NotImplementedException();
        }

        public bool CreateLease()
        {
            throw new NotImplementedException();
        }
    }
}