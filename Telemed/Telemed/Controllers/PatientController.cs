using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TelemedApi.Services;
using Utils.Models;

namespace TelemedApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly PatientService patientService;
        public PatientController(PatientService patientService)
        {
            this.patientService = patientService;
        }

        /// <summary>
        /// Returns a list of all Patients
        /// </summary>
        /// <returns>A list of patients</returns>
        [HttpGet]
        public ActionResult<List<Patient>> GetAllPatients()
        {
            return patientService.GetAllPatients();
        }

        /// <summary>
        /// Returns the patient with the specified id if it exists, returns a 404 otherwise
        /// </summary>
        /// <param name="id"></param>
        /// <returns>a patient</returns>
        [HttpGet("{id}", Name = "GetPatient")]
        public ActionResult<Patient> Get(string id)
        {
            var patient = patientService.GetPatient(id);

            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            return patient;
        }

        /// <summary>
        /// Creates and return a patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>A patient</returns>
        [HttpPost]
        public ActionResult<Patient> Post(Patient patient)
        {
            patientService.CreatePatient(patient);
            return CreatedAtRoute("GetPatient", new { id = patient.Id.ToString() }, patient);
        }

        /// <summary>
        /// Updates an existing patient if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedPatient"></param>
        /// <returns>The updated patient or an error if no patient was found with that ID</returns>
        [HttpPut("{id}")]
        public ActionResult<Patient> Update(string id, Patient updatedPatient)
        {
            var patient = patientService.GetPatient(id);

            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            patientService.UpdatePatient(id, updatedPatient);

            return NoContent();
        }

        /// <summary>
        /// Deletes the patient with specified id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult<Patient> Delete(string id)
        {
            var patient = patientService.GetPatient(id);

            if (patient == null)
            {
                return NotFound("Patient not found");
            }

            patientService.RemovePatient(patient.Id);

            return NoContent();
        }
    }
}
