namespace CleanArchitectureCQRS.Shared.Services;

public interface ISampleEntityReadService
{
    Task<bool> ExistsByNameAsync(string name);
}
