using Microsoft.AspNetCore.Mvc;
using Patients.Contracts.Patient;
using Patients.Models;
using Patients.Services.Patients;
using Patients.ServiceErrors;
using ErrorOr;

namespace Patients.Controllers;

[ApiController]
[Route("[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientsController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpPost]
    public IActionResult CreatePatient(CreatePatientRequest request)
    {
        var patient = new Patient(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.AdmissionDateTime,
            request.DischargeDateTime,
            request.Symptoms,
            request.Outcomes
        );

        ErrorOr<Patient> createPatientResult = _patientService.CreatePatient(patient);

        if (createPatientResult.IsError)
        {
            if (createPatientResult.FirstError == Errors.General.DuplicateEntry)
            {
                return Conflict(createPatientResult.FirstError.Description);
            }
            return StatusCode(500, "An error occurred while creating the patient.");
        }

        var response = new PatientResponse(
            patient.Guid,
            patient.Name,
            patient.Description,
            patient.AdmissionDateTime,
            patient.DischargeDateTime,
            patient.Symptoms,
            patient.Outcomes
        );

        return CreatedAtAction(nameof(GetPatient), new { id = patient.Guid }, response);
    }

    [HttpGet("{id:guid}", Name = "GetPatient")]
    public IActionResult GetPatient(Guid id)
    {
        ErrorOr<Patient> getPatientResult = _patientService.GetPatient(id);

        if (getPatientResult.IsError && getPatientResult.FirstError == Errors.Patient.NotFound)
        {
            return NotFound();
        }
        var patient = getPatientResult.Value;
        var response = new PatientResponse(
         patient.Guid,
         patient.Name,
         patient.Description,
         patient.AdmissionDateTime,
         patient.DischargeDateTime,
         patient.Symptoms,
         patient.Outcomes
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertPatient(Guid id, UpsertPatientRequest request)
    {
        var patient = new Patient(
            id,
            request.Name,
            request.Description,
            request.AdmissionDateTime,
            request.DischargeDateTime,
            request.Symptoms,
            request.Outcomes
        );

        ErrorOr<Patient> upsertPatientResult = _patientService.UpsertPatient(patient);

        if (upsertPatientResult.IsError)
        {
            return StatusCode(500, "An error occurred while upserting the patient.");
        }
        return Ok(upsertPatientResult.Value);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeletePatient(Guid id)
    {
        ErrorOr<bool> deletePatientResult = _patientService.DeletePatient(id);
        if (deletePatientResult.IsError)
        {
            if (deletePatientResult.FirstError == Errors.Patient.NotFound)
            {
                return NotFound();
            }
            return StatusCode(500, "An error occurred while deleting the patient.");
        }
        return NoContent();
    }
}
