using CleanArchitectureCQRS.Shared.Abstractions.Exceptions;

namespace CleanArchitectureCQRS.Command.Application.Exceptions;

    public class SampleEntityAlreadyExistsException : PublicException
    {
        public string Name { get; }

        public SampleEntityAlreadyExistsException(string name)
            : base($"sampleEntity with name '{name}' already exists.")
        {
            Name = name;
        }
    }
