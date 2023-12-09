namespace Patients.Contracts.Patient
{
    public record UpsertPatientRequest(
        string Name,
        string Description,
        DateTime AdmissionDateTime,
        DateTime DischargeDateTime,
        List<string> Symptoms,
        List<string> Outcomes
    );
}