using Catalyte.Apparel.Data.Interfaces;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Catalyte.Apparel.Providers.Providers
{
    /// <summary>
    /// This class provides the implementation of the IPatientProvider interface, providing service methods for patients.
    /// </summary>
    public class PatientProvider : IPatientProvider
    {
        private readonly ILogger<PatientProvider> _logger;
        private readonly IPatientRepository _patientRepository;

        public PatientProvider(IPatientRepository patientRepository, ILogger<PatientProvider> logger)
        {
            _logger = logger;
            _patientRepository = patientRepository;
        }

        /// <summary>
        /// Asynchronously retrieves the patient with the patient id from the database.
        /// </summary>
        /// <param name="patientId">The id of the patient to retrieve.</param>
        /// <returns>The patient.</returns>
        public async Task<Patient> GetPatientByIdAsync(int patientId)
        {
            Patient patient;

            try
            {
                patient = await _patientRepository.GetPatientByIdAsync(patientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (patient == null || patient == default)
            {
                _logger.LogInformation($"Product with id: {patientId} could not be found.");
                throw new NotFoundException($"Product with id: {patientId} could not be found.");
            }

            return patient;
        }

        /// <summary>
        /// Asynchronously retrieves all patients from the database.
        /// </summary>
        /// <returns>All patients in the database.</returns>
        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            IEnumerable<Patient> patients;

            try
            {
                patients = await _patientRepository.GetPatientsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return patients;
        }

        /// <summary>
        /// Persists updated patient information.
        /// </summary>
        /// <param name="id">Id of the patient to update.</param>
        /// <param name="updatedPatient">Updated patient information to persist.</param>
        /// <returns>The updated product.</returns>
        public async Task<Patient> UpdatePatientAsync(int patientId, Patient updatedPatient)
        {
            try
            {
                var existingPatient = await _patientRepository.GetPatientByIdAsync(patientId);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            /*if (existingPatient == null || existingPatient == default)
            {
                _logger.LogInformation($"Product with id: {patientId} could not be found.");
                throw new NotFoundException($"Product with id: {patientId} could not be found.");
            }*/

            bool emailExists = await _patientRepository.CheckEmailExistsAsync(updatedPatient.Email);
            if (emailExists)
            {
                throw new ConflictException("Email already exists.");
            }

            await ValidatePatientAsync(updatedPatient);
            updatedPatient.DateModified = DateTime.UtcNow;
            if (updatedPatient.Id == default)
                updatedPatient.Id = patientId;

            try
            {
                await _patientRepository.UpdatePatientAsync(updatedPatient);
                _logger.LogInformation("Product updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return updatedPatient;
        }

        public async Task<Encounter> UpdateEncounterAsync(int patientId, int encounterId, Encounter updatedEncounter)
        {
            Encounter existingEncounter;

            try
            {
                existingEncounter = await _patientRepository.GetEncounterByIdAsync(encounterId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingEncounter == null)
            {
                throw new NotFoundException("Encounter not found.");
            }
            await ValidateEncounterAsync(updatedEncounter);
            if (updatedEncounter.Id == default)
                updatedEncounter.Id = encounterId;

            try
            {
                await _patientRepository.UpdateEncounterAsync(updatedEncounter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return updatedEncounter;
        }

        /// <summary>
        /// Deletes patient.
        /// </summary>
        /// <param name="id">Id of the patient to delete.</param>
        /// <returns>The deleted patient.</returns>
        public async Task<Patient> DeletePatientAsync(int id)
        {
            Patient existingPatient;
            Patient deletedPatient;

            try
            {
                existingPatient = await _patientRepository.GetPatientByIdAsync(id);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            if (existingPatient == null || existingPatient == default)
            {
                _logger.LogInformation($"Patient with id: {id} could not be found.");
                throw new NotFoundException($"Patient with id: {id} could not be found.");
            }

            try
            {
                deletedPatient = await _patientRepository.DeletePatientAsync(existingPatient);
                _logger.LogInformation("Product deleted");
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return deletedPatient;
        }

        /// <summary>
        /// Asynchronously creates a new patient in the database.
        /// </summary>
        /// <param name="patient">A patient in the database </param>
        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            //Sets the DateCreated and DateModified to the current date/time when the API request is made
            DateTime currentTime = DateTime.UtcNow;

            patient.DateCreated = currentTime;
            patient.DateModified = currentTime;

            await ValidatePatientAsync(patient);

            Patient newPatient;

            try
            {
                newPatient = await _patientRepository.CreatePatientAsync(patient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return newPatient;

        }

        private async Task ValidatePatientAsync(Patient patient)
        {
            bool emailExists = await _patientRepository.CheckEmailExistsAsync(patient.Email);
            if (emailExists)
            {
                throw new ConflictException("Email already exists.");
            }

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

        private async Task ValidateEncounterAsync(Encounter encounter)
        {
            if (string.IsNullOrWhiteSpace(encounter.VisitCode))
            {
                throw new AggregateException("VisitCode cannot be blank.");
            }
            if (!Regex.IsMatch(encounter.VisitCode, "^[A-Z0-9]{3} [A-Z0-9]{3}$"))
            {
                throw new AggregateException("VisitCode must have only capital letters and/or numbers.");
            }

            if (string.IsNullOrWhiteSpace(encounter.Provider))
            {
                throw new AggregateException("Provider cannot be blank.");
            }
            if (string.IsNullOrEmpty(encounter.BillingCode))
            {
                throw new AggregateException("BillingCode cannot be blank.");
            }
            if (!Regex.IsMatch(encounter.BillingCode, "^\\d{3}\\.\\d{3}\\.\\d{3}-\\d{2}$"))
            {
                throw new AggregateException("BillingCode must be in the format XXX.XXX.XXX-XX.");
            }

            if (string.IsNullOrWhiteSpace(encounter.Icd10Code))
            {
                throw new AggregateException("Icd10Code cannot be blank.");
            }
            if (!Regex.IsMatch(encounter.Icd10Code, @"^[A-Z]\d{2}$"))
            {
                throw new AggregateException("Icd10Code must be in the format X11.");
            }

            if (encounter.TotalCost <= 0)
            {
                throw new AggregateException("Total cost must be a positive number.");
            }
            if (encounter.Copay <= 0)
            {
                throw new AggregateException("Copay must be a positive number.");
            }
            if (string.IsNullOrWhiteSpace(encounter.ChiefComplaint))
            {
                throw new AggregateException("ChiefComplaint cannot be blank.");
            }
            string formattedDate = encounter.Date.ToString("yyyy-MM-dd");
            Regex regex = new Regex(@"^\d{4}-\d{2}-\d{2}$");
            if (!regex.IsMatch(formattedDate))
            {
                throw new AggregateException("Date must be in the format YYYY-MM-DD");
            }

            await Task.Delay(100);
        }

        public async Task<Encounter> CreateEncounterAsync(Encounter encounter)
        {
            //Sets the DateCreated and DateModified to the current date/time when the API request is made
            DateTime currentTime = DateTime.UtcNow;

            encounter.DateCreated = currentTime;
            encounter.DateModified = currentTime;
            await ValidateEncounterAsync(encounter);

            Encounter newEncounter;

            try
            {
                newEncounter = await _patientRepository.CreateEncounterAsync(encounter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ServiceUnavailableException("There was a problem connecting to the database.");
            }

            return newEncounter;

        }

        public Task CreatePatientAsync(PatientDTO patient)
        {
            throw new NotImplementedException();
        }

        public Task GetEncounterAsync(int patientId, int encounterId)
        {
            throw new NotImplementedException();
        }

        public Task<Encounter> GetEncounterAsync(int encounterId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasEncountersAsync(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}
