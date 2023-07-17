using Catalyte.Apparel.Data.Context;
using Catalyte.Apparel.Data.Filters;
using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs.Products;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Data.Repositories
{
    /// <summary>
    /// This class handles methods for making requests to the patient repository.
    /// </summary>
    public class PatientRepository : IPatientRepository
    {
        private readonly IApparelCtx _ctx;

        public PatientRepository(IApparelCtx ctx)
        {
            _ctx = ctx;
        }

        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            return await _ctx.Patients
                .AsNoTracking()
                .WherePatientIdEquals(patientId)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            return await _ctx.Patients
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            _ctx.Patients.Update(patient);
            await _ctx.SaveChangesAsync();
            return patient;
        }
        public async Task<Encounter> UpdateEncounterAsync(Encounter encounter)
        {
            _ctx.Encounters.Update(encounter);
            await _ctx.SaveChangesAsync();
            return encounter;
        }

        public async Task<Patient> DeletePatientAsync(Patient patient)
        {
            _ctx.Patients.Remove(patient);
            await _ctx.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            await _ctx.Patients.AddAsync(patient);
            await _ctx.SaveChangesAsync();

            return patient;
        }
        public async Task<Encounter> CreateEncounterAsync(Encounter encounter)
        {
            await _ctx.Encounters.AddAsync(encounter);
            await _ctx.SaveChangesAsync();

            return encounter;
        }

        public Task CreatePatientAsync(PatientDTO patient)
        {
            throw new System.NotImplementedException();
        }

        public Task<Patient> UpdatePatientAsync(int patientId, Patient patient)
        {
            throw new System.NotImplementedException();
        }

        public Task<Encounter> UpdateEncounterAsync(int patientId, int encounterId, Encounter encounter)
        {
            throw new System.NotImplementedException();
        }

        public Task GetPatientByIdAsync(Patient updatedPatient)
        {
            throw new System.NotImplementedException();
        }
        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            bool emailExists = await _ctx.Patients.AnyAsync(p => p.Email == email);
            return emailExists;
        }

        public async Task<Encounter> GetEncounterByIdAsync(int encounterId)
        {
            return await _ctx.Encounters
                .AsNoTracking()
                .WhereEncounterIdEquals(encounterId)
                .SingleOrDefaultAsync();
        }
    }
}