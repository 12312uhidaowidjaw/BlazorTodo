using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class CoreExntesion
    {
        public static void ConfigureApplication(this IServiceCollection service, IConfiguration config)
        {
            service.ConfigureConnection(config);
            service.ConfigureRepository();
            service.ConfigureService();
            service.ConfigureMapper();
        }
    }
}