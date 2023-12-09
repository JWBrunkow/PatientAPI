namespace Patients.Contracts.Patient
{
    public record CreatePatientRequest(
        string Name,
        string Description,
        DateTime AdmissionDateTime,
        DateTime DischargeDateTime,
        List<string> Symptoms,
        List<string> Outcomes
    );
}