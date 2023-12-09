using System;
using System.Collections.Generic;

namespace Patients.Models
{
    public class Patient
    {
        public Patient(Guid guid,
                       string name,
                       string description,
                       DateTime admissionDateTime,
                       DateTime dischargeDateTime,
                       List<string> symptoms,
                       List<string> outcomes)
        {
            Guid = guid;
            Name = name;
            Description = description;
            AdmissionDateTime = admissionDateTime;
            DischargeDateTime = dischargeDateTime;
            Symptoms = symptoms ?? new List<string>();
            Outcomes = outcomes ?? new List<string>();
        }

        public Guid Guid { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime AdmissionDateTime { get; }
        public DateTime DischargeDateTime { get; }
        public List<string> Symptoms { get; }
        public List<string> Outcomes { get; }
    }
}
