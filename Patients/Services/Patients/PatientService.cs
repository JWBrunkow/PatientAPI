using ErrorOr;
using Patients.Models;
using Patients.ServiceErrors;
using System.Collections.Generic;

namespace Patients.Services.Patients
{
    public class PatientService : IPatientService
    {
        private static readonly Dictionary<Guid, Patient> _patients = new Dictionary<Guid, Patient>();

        public ErrorOr<Patient> CreatePatient(Patient patient)
        {
            if (_patients.ContainsKey(patient.Guid))
            {
                // You can define a specific error for duplicate entry
                return Errors.General.DuplicateEntry; // Define this error in your Errors class
            }
            _patients.Add(patient.Guid, patient);
            return patient;
        }

        public ErrorOr<bool> DeletePatient(Guid id)
        {
            bool removed = _patients.Remove(id);
            return removed ? true : Errors.Patient.NotFound;
        }

        public ErrorOr<Patient> UpsertPatient(Patient patient)
        {
            _patients[patient.Guid] = patient;
            return patient;
        }

        public ErrorOr<Patient> GetPatient(Guid guid)
        {
            if (_patients.TryGetValue(guid, out var patient))
            {
                return patient;
            }
            return Errors.Patient.NotFound;
        }
    }
}
