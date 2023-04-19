using CleanArchitectureCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchitectureCQRS.Domain.Exceptions;

    public class SampleInvalidException : PublicException
    {

        public SampleInvalidException() : base("Sample ID cannot be empty.")
        {
        }
    }
