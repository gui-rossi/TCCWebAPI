using Microsoft.Extensions.DependencyInjection;
using TCCRepositories.DataRepository;
using TCCRepositories.Interfaces;

namespace TCCRepositories.DIRepository
{
    public static class DIRepository
    {
        public static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }
    }
}
