using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ConnectionExtension
    {
        public static void ConfigureConnection(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<TodoContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("Default"));
            });
        }
    }
}