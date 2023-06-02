using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCBusiness.Interfaces;
using TCCBusiness.Services;

namespace TCCBusiness.DIBusiness
{
    public static class DIBusiness
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IConfigurationsService, ConfigurationsService>();
            services.AddTransient<ICameraService, CameraService>();
        }
    }
}
