namespace CleanArchitectureCQRS.Shared.Abstractions.Exceptions;

    public abstract class PublicException : Exception
    {
        protected PublicException(string message) : base(message)
        {

        }
    }
