using TCCDomain.ViewModels;

namespace TCCBusiness.Interfaces
{
    public interface IConfigurationsService
    {
        Task UpdateConfigurations(ConfigurationsViewModel configsVM);
    }
}
