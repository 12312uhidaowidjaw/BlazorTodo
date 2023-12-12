using Core.Interface.Repository;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class RepositoryExtension
    {
        public static void ConfigureRepository(this IServiceCollection service)
        {
            service.AddTransient<ITodoRepository, TodoRepository>();
        }
    }
}