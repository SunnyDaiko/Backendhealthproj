using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for patient repository methods.
    /// </summary>
    public interface IPatientRepository
    {
        Task<Patient> GetPatientByIdAsync(int patientId);

        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<Patient> UpdatePatientAsync(Patient patient);

        Task<Patient> DeletePatientAsync(Patient patient);

        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Encounter> CreateEncounterAsync(Encounter encounter);

        Task CreatePatientAsync(PatientDTO patient);
        Task GetPatientByIdAsync(Patient updatedPatient);

        Task<bool> CheckEmailExistsAsync(string email);

        Task<Encounter> UpdateEncounterAsync(int patientId, int encounterId, Encounter encounter);
        Task<Encounter> UpdateEncounterAsync(Encounter encounter);
        Task<Encounter> GetEncounterByIdAsync(int encounterId);
    }
}
