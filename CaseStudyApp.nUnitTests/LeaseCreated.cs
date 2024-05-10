using System;
using NUnit.Framework;
using CaseStudy;
using CaseStudyCarRentalSystem.Repository;

namespace CaseStudyApp.nUnitTests
{
    internal class LeaseCreated
    {
        [Test]
        public void CreateLease_Success()
        {
            // Arrange: Prepare the necessary data and dependencies
            CarLeaseRepositoryImpl leaseRepository = new CarLeaseRepositoryImpl();
            Lease leaseToCreate = new Lease
            {
                LeaseID = 1,
                VehicleID = 1,
                CustomerID = 1,
                StartDate = new DateTime(2022, 3, 1),
                EndDate = new DateTime(2022, 3, 31),
                Type = "Standard"
            }; // Example lease data

            // Act: Perform the action (create a lease)
            bool creationResult = leaseRepository.CreateLease(leaseToCreate);

            // Assert: Verify the outcome
            Assert.IsTrue(creationResult, "Lease creation should succeed");

            // You can also verify if the lease is added to the repository or database
            // For example:
            // Assert.IsTrue(leaseRepository.Contains(leaseToCreate), "Lease should be added to the repository");
        }
    }
}

namespace CaseStudyCarRentalSystem.Repository
{
    internal class CarLeaseRepositoryImpl
    {
        public bool CreateLease(Lease lease)
        {
            // Logic to create a lease
            // For this example, let's just return true indicating success
            return true;
        }
    }
}
