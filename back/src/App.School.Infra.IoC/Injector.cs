using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace App.School.Infra.IoC
{
    public static class Injector
    {
        public static void AddInjectorServices(this IServiceCollection services)
        {
            services.AddMediatR(
                config => config.AsScoped(),
                AppDomain.CurrentDomain.Load("App.School.Application")
            );
        }
    }
}
