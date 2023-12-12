using AutoMapper;
using Core.Mapper;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Extensions
{
    public static class MapperExtension
    {
        public static void ConfigureMapper(this IServiceCollection service)
        {
            service.AddTransient(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new TodoMapper());
            }).CreateMapper());
        }
    }
}