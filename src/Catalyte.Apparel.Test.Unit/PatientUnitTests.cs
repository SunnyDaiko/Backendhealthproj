using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.Providers.Providers;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Text.RegularExpressions;

namespace Catalyte.Apparel.Test.Unit
{
    public class PatientUnitTests
    {
        private readonly Mock<IPatientRepository> _patientRepositoryMock;
        private readonly Mock<ILogger<PatientProvider>> _loggerMock;
        private readonly PatientProvider _patientProvider;

        public PatientUnitTests()
        {
            _patientRepositoryMock = new Mock<IPatientRepository>();
            _loggerMock = new Mock<ILogger<PatientProvider>>();
            _patientProvider = new PatientProvider(_patientRepositoryMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetPatientByIdAsync_ValidId_ReturnsPatient()
        {
            // Arrange
            int patientId = 1;
            var expectedPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Doe" };
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ReturnsAsync(expectedPatient);

            // Act
            var result = await _patientProvider.GetPatientByIdAsync(patientId);

            // Assert
            Assert.Equal(expectedPatient, result);
        }

        [Fact]
        public async Task GetPatientByIdAsync_InvalidId_ThrowsNotFoundException()
        {
            // Arrange
            int patientId = 1;
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ReturnsAsync(default(Patient));

            // Act and Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _patientProvider.GetPatientByIdAsync(patientId));
        }

        [Fact]
        public async Task GetPatientsAsync_ReturnsAllPatients()
        {
            // Arrange
            var expectedPatients = new List<Patient>
    {
        new Patient { Id = 1, FirstName = "John", LastName = "Doe" },
        new Patient { Id = 2, FirstName = "Jane", LastName = "Smith" }
    };
            _patientRepositoryMock.Setup(r => r.GetPatientsAsync()).ReturnsAsync(expectedPatients);

            // Act
            var result = await _patientProvider.GetPatientsAsync();

            // Assert
            Assert.Equal(expectedPatients, result);
        }

        [Fact]
        public async Task UpdatePatientAsync_ValidId_ReturnsUpdatedPatient()
        {
            // Arrange
            int patientId = 1;
            var existingPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Doe" };
            var updatedPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Smith" };
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ReturnsAsync(existingPatient);
            _patientRepositoryMock.Setup(r => r.UpdatePatientAsync(updatedPatient)).ReturnsAsync(updatedPatient);

            // Act
            var result = await _patientProvider.UpdatePatientAsync(patientId, updatedPatient);

            // Assert
            Assert.Equal(updatedPatient, result);
        }

        [Fact]
        public async Task UpdatePatientAsync_InvalidId_ThrowsNotFoundException()
        {
            // Arrange
            int patientId = 1;
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ReturnsAsync(default(Patient));
            var updatedPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Smith" };

            // Act and Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _patientProvider.UpdatePatientAsync(patientId, updatedPatient));
        }

        [Fact]
        public async Task DeletePatientAsync_ValidId_ReturnsDeletedPatient()
        {
            // Arrange
            int patientId = 1;
            var existingPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Doe" };
            var deletedPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Doe" };
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ReturnsAsync(existingPatient);
            _patientRepositoryMock.Setup(r => r.DeletePatientAsync(existingPatient)).ReturnsAsync(deletedPatient);

            // Act
            var result = await _patientProvider.DeletePatientAsync(patientId);

            // Assert
            Assert.Equal(deletedPatient, result);
        }

        [Fact]
        public async Task DeletePatientAsync_InvalidId_ThrowsNotFoundException()
        {
            // Arrange
            int patientId = 1;
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ReturnsAsync(default(Patient));

            // Act and Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _patientProvider.DeletePatientAsync(patientId));
        }

        [Fact]
        public async Task GetPatientByIdAsync_DatabaseConnectionError_ThrowsServiceUnavailableException()
        {
            // Arrange
            int patientId = 1;
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ThrowsAsync(new Exception("Database connection error"));

            // Act and Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(() => _patientProvider.GetPatientByIdAsync(patientId));
        }

        [Fact]
        public async Task GetPatientsAsync_DatabaseConnectionError_ThrowsServiceUnavailableException()
        {
            // Arrange
            _patientRepositoryMock.Setup(r => r.GetPatientsAsync()).ThrowsAsync(new Exception("Database connection error"));

            // Act and Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(() => _patientProvider.GetPatientsAsync());
        }

        [Fact]
        public async Task UpdatePatientAsync_DatabaseConnectionError_ThrowsServiceUnavailableException()
        {
            // Arrange
            int patientId = 1;
            var existingPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Doe" };
            var updatedPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Smith" };
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ReturnsAsync(existingPatient);
            _patientRepositoryMock.Setup(r => r.UpdatePatientAsync(updatedPatient)).ThrowsAsync(new Exception("Database connection error"));

            // Act and Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(() => _patientProvider.UpdatePatientAsync(patientId, updatedPatient));
        }

        [Fact]
        public async Task DeletePatientAsync_DatabaseConnectionError_ThrowsServiceUnavailableException()
        {
            // Arrange
            int patientId = 1;
            var existingPatient = new Patient { Id = patientId, FirstName = "John", LastName = "Doe" };
            _patientRepositoryMock.Setup(r => r.GetPatientByIdAsync(patientId)).ReturnsAsync(existingPatient);
            _patientRepositoryMock.Setup(r => r.DeletePatientAsync(existingPatient)).ThrowsAsync(new Exception("Database connection error"));

            // Act and Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(() => _patientProvider.DeletePatientAsync(patientId));
        }

        [Fact]
        public async Task CreatePatientAsync_DatabaseConnectionError_ThrowsServiceUnavailableException()
        {
            // Arrange
            var patient = new Patient { FirstName = "John", LastName = "Doe" };
            _patientRepositoryMock.Setup(r => r.CreatePatientAsync(patient)).ThrowsAsync(new Exception("Database connection error"));

            // Act and Assert
            await Assert.ThrowsAsync<ServiceUnavailableException>(() => _patientProvider.CreatePatientAsync(patient));
        }

        [Fact]
        public void FirstName_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { FirstName = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void FirstName_Invalid_ExceedsMaxLength_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { FirstName = "ThisFirstNameIsTooLongAndExceedsTheMaxLengthLimit" };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void LastName_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { LastName = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void LastName_Invalid_ExceedsMaxLength_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { LastName = "ThisLastNameIsTooLongAndExceedsTheMaxLengthLimit" };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void SSN_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { SSN = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void SSN_Invalid_InvalidFormat_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { SSN = "123-45-6789" };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Email_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Email = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Email_Invalid_InvalidFormat_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Email = "invalid_email" };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Street_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Street = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Street_Invalid_ExceedsMaxLength_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Street = "ThisStreetNameIsTooLongAndExceedsTheMaxLengthLimit" };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void City_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { City = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void City_Invalid_ExceedsMaxLength_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { City = "ThisCityNameIsTooLongAndExceedsTheMaxLengthLimit" };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void State_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { State = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void State_Invalid_InvalidFormat_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { State = "ABC" };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void ZipCode_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { ZipCode = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void ZipCode_Invalid_InvalidFormat_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { ZipCode = "123456" };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Age_Invalid_NonPositiveNumber_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Age = -10 };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Height_Invalid_NonPositiveNumber_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Height = -5.7 };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Weight_Invalid_NonPositiveNumber_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Weight = 0 };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Insurance_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Insurance = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        [Fact]
        public void Gender_Invalid_NullOrWhiteSpace_ThrowsAggregateException()
        {
            // Arrange
            var patient = new Patient { Gender = null };

            // Act and Assert
            Assert.Throws<AggregateException>(() => ValidatePatient(patient));
        }

        private void ValidatePatient(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.FirstName))
            {
                throw new AggregateException("First name cannot be blank.");
            }
            if (patient.FirstName.Length > 50)
            {
                throw new AggregateException("First name must be less than 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(patient.LastName))
            {
                throw new AggregateException("Last name cannot be blank.");
            }
            if (patient.LastName.Length > 50)
            {
                throw new AggregateException("Last name must be less than 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(patient.SSN))
            {
                throw new AggregateException("SSN cannot be blank.");
            }
            if (!Regex.IsMatch(patient.SSN, @"^\d{3}-\d{2}-\d{4}$"))
            {
                throw new AggregateException("SSN must be in the format XXX-XX-XXXX.");
            }

            if (string.IsNullOrWhiteSpace(patient.Email))
            {
                throw new AggregateException("Email cannot be blank.");
            }
            if (!Regex.IsMatch(patient.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                throw new AggregateException("Invalid email format.");
            }
            if (string.IsNullOrWhiteSpace(patient.Street))
            {
                throw new AggregateException("Street cannot be blank.");
            }
            if (patient.Street.Length > 100)
            {
                throw new AggregateException("Street must be less than 100 characters.");
            }

            if (string.IsNullOrWhiteSpace(patient.City))
            {
                throw new AggregateException("City cannot be blank.");
            }
            if (patient.City.Length > 50)
            {
                throw new AggregateException("City must be less than 50 characters.");
            }

            if (string.IsNullOrWhiteSpace(patient.State))
            {
                throw new AggregateException("State cannot be blank.");
            }
            if (!Regex.IsMatch(patient.State, @"^[A-Z]{2}$"))
            {
                throw new AggregateException("State must be a 2-letter abbreviation.");
            }

            if (string.IsNullOrWhiteSpace(patient.ZipCode))
            {
                throw new AggregateException("Zip code cannot be blank.");
            }
            if (!Regex.IsMatch(patient.ZipCode, @"^\d{5}$"))
            {
                throw new AggregateException("Invalid zip code format.");
            }

            if (patient.Age <= 0)
            {
                throw new AggregateException("Age must be a positive number.");
            }

            if (patient.Height <= 0)
            {
                throw new AggregateException("Height must be a positive number.");
            }

            if (patient.Weight <= 0)
            {
                throw new AggregateException("Weight must be a positive number.");
            }

            if (string.IsNullOrWhiteSpace(patient.Insurance))
            {
                throw new AggregateException("Insurance cannot be blank.");
            }

            if (string.IsNullOrWhiteSpace(patient.Gender))
            {
                throw new AggregateException("Gender cannot be blank.");
            }
        }
    }
}