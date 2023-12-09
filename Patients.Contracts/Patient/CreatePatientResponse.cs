namespace Patients.Contracts.Patient
{
    public record PatientResponse(
        Guid Guid,
        string Name,
        string Description,
        DateTime AdmissionDateTime,
        DateTime DischargeDateTime,
        List<string> Symptoms,
        List<string> Outcomes
    );
}