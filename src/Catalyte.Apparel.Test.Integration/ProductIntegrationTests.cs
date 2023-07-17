using Catalyte.Apparel.DTOs.Encounter;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Test.Integration.Utilities;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.Apparel.Test.Integration
{
    [Collection("Sequential")]
    public class ProductIntegrationTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public ProductIntegrationTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task GetPatients_Returns200()
        {
            var response = await _client.GetAsync("/patients");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetPatientById_GivenExistingId_Returns200()
        {
            var response = await _client.GetAsync("/patients/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<PatientDTO>();
            Assert.Equal(1, content.Id);
        }

        [Fact]
        public async Task UpdatePatientAsync_GivenExistingId_Returns200()
        {
            var response = await _client.GetAsync("/patients/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<PatientDTO>();
            Assert.Equal(1, content.Id);
        }

        [Fact]
        public async Task UpdatePatient_GivenNonExistingId_Returns404()
        {
            // Arrange
            var nonExistingId = 100;
            var patientToUpdate = new PatientDTO { Id = nonExistingId, FirstName = "Updated Name" };

            // Act
            var response = await _client.PutAsJsonAsync($"/patients/{nonExistingId}", patientToUpdate);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task UpdateEncounter_Returns200()
        {
            // Arrange
            var patientId = 1;
            var encounterId = 1;
            var encounterToUpdate = new EncounterDTO { PatientId = encounterId };

            // Act
            var response = await _client.PutAsJsonAsync($"/patients/{patientId}/encounters/{encounterId}", encounterToUpdate);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var updatedEncounter = await response.Content.ReadAsAsync<EncounterDTO>();
            Assert.Equal(encounterId, updatedEncounter.PatientId);
            Assert.Equal(encounterToUpdate, updatedEncounter);
        }

        [Fact]
        public async Task UpdateEncounter_GivenNonExistingPatientId_Returns404()
        {
            // Arrange
            var nonExistingPatientId = 100;
            var encounterId = 1;
            var encounterToUpdate = new EncounterDTO { PatientId = encounterId };

            // Act
            var response = await _client.PutAsJsonAsync($"/patients/{nonExistingPatientId}/encounters/{encounterId}", encounterToUpdate);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task UpdateEncounter_GivenNonExistingEncounterId_Returns404()
        {
            // Arrange
            var patientId = 1;
            var nonExistingEncounterId = 100;
            var encounterToUpdate = new EncounterDTO { PatientId = nonExistingEncounterId };

            // Act
            var response = await _client.PutAsJsonAsync($"/patients/{patientId}/encounters/{nonExistingEncounterId}", encounterToUpdate);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreatePatient_Returns201()
        {
            // Arrange
            var newPatient = new PatientDTO { FirstName = "New Patient" };

            // Act
            var response = await _client.PostAsJsonAsync("/patients", newPatient);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var createdPatient = await response.Content.ReadAsAsync<PatientDTO>();
            Assert.NotNull(createdPatient.Id);
            Assert.Equal(newPatient.FirstName, createdPatient.FirstName);
        }

        [Fact]
        public async Task CreateEncounter_Returns201()
        {
            // Arrange
            var patientId = 1;
            var newEncounter = new EncounterDTO { EncounterId = 1 };

            // Act
            var response = await _client.PostAsJsonAsync($"/patients/{patientId}/encounters", newEncounter);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

            var createdEncounter = await response.Content.ReadAsAsync<EncounterDTO>();
            Assert.Equal(patientId, createdEncounter.PatientId);
            Assert.Equal(newEncounter, createdEncounter);
        }

        [Fact]
        public async Task DeletePatient_Returns204()
        {
            // Arrange
            var patientId = 1;

            // Act
            var response = await _client.DeleteAsync($"/patients/{patientId}");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeletePatient_GivenNonExistingId_Returns404()
        {
            // Arrange
            var nonExistingId = 100;

            // Act
            var response = await _client.DeleteAsync($"/patients/{nonExistingId}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
