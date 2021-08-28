using Microsoft.Extensions.DependencyInjection;
using NumberDecompose.Business.Interface;
using NumberDecompose.Business.Service;
using NumberDecompose.Data.Context;
using NumberDecompose.Data.Interface;
using NumberDecompose.Data.Repository;

namespace NumberDecompose.Injections
{
    public static class DependencyInjections
    {
        public static void AddDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped<INumberService, NumberService>();
            services.AddScoped<INumberRepository, NumberRepository>();

            services.AddSingleton<DataContext>();
        }
    }
}