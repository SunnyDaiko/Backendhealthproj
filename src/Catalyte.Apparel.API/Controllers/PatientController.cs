using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.API.DTOMappings;
using Catalyte.Apparel.Data.Models;
using Catalyte.Apparel.DTOs.Encounter;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The ProductsController exposes endpoints for patient related actions.
    /// </summary>
    [ApiController]
    [Route("/patients")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientProvider _patientProvider;
        private readonly IMapper _mapper;

        public PatientController(
            ILogger<PatientController> logger,
            IPatientProvider patientProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _patientProvider = patientProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDTO>>> GetPatientsAsync()
        {
            _logger.LogInformation("Request received for GetProductsAsync");

            var patients = await _patientProvider.GetPatientsAsync();
            var patientDTOs = _mapper.Map<IEnumerable<PatientDTO>>(patients);

            return Ok(patientDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientDTO>> GetPatientByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetProductByIdAsync for id: {id}");

            var patient = await _patientProvider.GetPatientByIdAsync(id);
            var patientDTO = _mapper.Map<PatientDTO>(patient);

            return Ok(patientDTO);
        }

        [HttpPut("{patientId}")]
        public async Task<ActionResult<PatientDTO>> UpdatePatientAsync(int patientId, [FromBody] PatientDTO patientToUpdate)
        {
            _logger.LogInformation("Request received for UpdateProductAsync");

            try
            {
                var patient = _mapper.Map<Patient>(patientToUpdate);
                var updatedPatient = await _patientProvider.UpdatePatientAsync(patientId, patient);
                var patientDTO = _mapper.Map<PatientDTO>(updatedPatient);
                return Ok(patient);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "There was a problem connecting to the database.");
            }
            catch (ConflictException)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Email already exists.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/encounters/{encounterId}")]
        public async Task<ActionResult<EncounterDTO>> UpdateEncounterAsync(int id, int encounterId, [FromBody] EncounterDTO encounterToUpdate)
        {
            _logger.LogInformation("Request received for UpdateEncounterAsync");
            var encounter = _mapper.Map<Encounter>(encounterToUpdate);
            var updatedEncounterDTO = _mapper.Map<EncounterDTO>(encounterToUpdate);
            var patient = await _patientProvider.GetPatientByIdAsync(id);

            if (patient == null)
            {
                return NotFound($"Patient with id {id} not found.");
            }

            // Set the PatientId of the encounter to match the patient's Id
            encounter.PatientId = patient.Id;

            try
            {
                var updatedEncounter = await _patientProvider.UpdateEncounterAsync(id, encounterId, encounter);
                return Ok(updatedEncounter);
            }
            catch (NotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Encounter does not exist.");
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "There was a problem connecting to the database.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<PatientDTO>> CreatePatientAsync([FromBody] PatientDTO patient)
        {
            _logger.LogInformation("Request received for CreatePromoCode");
            var newPatient = _mapper.MapCreatePatientDTOToPatient(patient);
            try
            {
                var createdPatient = await _patientProvider.CreatePatientAsync(newPatient);
                return StatusCode(201, createdPatient);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "There was a problem connecting to the database.");
            }
            catch (ConflictException)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Email already exists.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/encounters")]
        public async Task<ActionResult<EncounterDTO>> CreateEncounterAsync(int id, [FromBody] EncounterDTO encounter)
        {
            _logger.LogInformation($"Request received for CreateEncounterAsync for patient id: {id}");
            var patient = await _patientProvider.GetPatientByIdAsync(id);

            if (patient == null)
            {
                return NotFound($"Patient with id {id} not found.");
            }

            // Set the PatientId of the encounter to match the patient's Id
            encounter.PatientId = patient.Id;
            var newEncounter = _mapper.MapCreateEncounterDTOToEncounter(encounter);
            try
            {
                var createdEncounter = await _patientProvider.CreateEncounterAsync(newEncounter);
                return StatusCode(StatusCodes.Status201Created, createdEncounter);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "There was a problem connecting to the database.");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AggregateException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientDTO>> DeletePatientAsync(int id)
        {
            _logger.LogInformation("Request received for DeleteProductAsync");
            /*var hasEncounters = await _patientProvider.HasEncountersAsync(id);
            if (hasEncounters)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Patient has encounters and cannot be deleted.");
            }*/

            var deletedPatient = await _patientProvider.DeletePatientAsync(id);

            try
            {
                var patientDTO = _mapper.Map<PatientDTO>(deletedPatient);
                return StatusCode(StatusCodes.Status204NoContent, patientDTO);
            }
            catch (NotFoundException)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Encounter does not exist.");
            }
            catch (InvalidOperationException)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "There was a problem connecting to the database.");
            }
        }
    }
}
