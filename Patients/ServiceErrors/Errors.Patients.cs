using ErrorOr;

namespace Patients.ServiceErrors
{
    public static class Errors
    {
        public static class Patient
        {
            public static Error NotFound => Error.NotFound(
                code: "Patient.NotFound",
                description: "Patient not found"
            );
        }

        public static class General
        {
            public static Error DuplicateEntry => Error.Validation(
                code: "General.DuplicateEntry",
                description: "The specified entry already exists"
            );
        }
    }
}

