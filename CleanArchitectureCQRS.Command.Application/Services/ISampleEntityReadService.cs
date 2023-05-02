namespace CleanArchitectureCQRS.Command.Application.Services;

public interface ISampleEntityReadService
{
    Task<bool> ExistsByNameAsync(string name);
}
