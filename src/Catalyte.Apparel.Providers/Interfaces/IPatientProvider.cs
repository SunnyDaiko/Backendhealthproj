using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for patient related service methods.
    /// </summary>
    public interface IPatientProvider
    {
        Task<Patient> GetPatientByIdAsync(int patientId);

        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<Patient> UpdatePatientAsync(int id, Patient patient);

        Task<Patient> DeletePatientAsync(int id);

        Task<Patient> CreatePatientAsync(Patient patient);

        Task CreatePatientAsync(PatientDTO patient);

        Task<Encounter> UpdateEncounterAsync(int patientId, int encounterId, Encounter encounter);

        Task<Encounter> GetEncounterAsync(int encounterId);
        Task<Encounter> CreateEncounterAsync(Encounter encounter);
    }
}
