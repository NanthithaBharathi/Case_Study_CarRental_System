using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

using CaseStudyCarRentalSystem.Repository;

namespace CaseStudyApp.nUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }


}


/*
 * internal class CarCreateTest
    {

        [TestFixture]
        public class CarTests
        {
            [Test]
            public void CreateCar_Success()
            {
                // Arrange: Prepare the necessary data and dependencies
                CarLeaseRepositoryImpl carRepository = new CarLeaseRepositoryImpl();

                // Act: Perform the action (create a car)
                bool creationResult = carRepository.AddCar();

                // Assert: Verify the outcome
                Assert.IsTrue(creationResult, "Car creation should succeed");

                // Optionally, you can also verify if the car is added to the repository or database
                //Assert.IsTrue(carRepository.AddCar(), "Car should be added to the repository");
            }
        }
    }*/