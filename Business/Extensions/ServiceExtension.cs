using Business.Service;
using Core.Interface.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureService(this IServiceCollection service)
        {
            service.AddTransient<ITodoService, TodoService>();
        }
    }
}