using ErrorOr;
using Patients.Models;

namespace Patients.Services.Patients
{
    public interface IPatientService
    {
        ErrorOr<Patient> CreatePatient(Patient patient);
        ErrorOr<bool> DeletePatient(Guid id);
        ErrorOr<Patient> GetPatient(Guid guid);
        ErrorOr<Patient> UpsertPatient(Patient patient);
    }
}
