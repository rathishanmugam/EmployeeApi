using EmployeeApi.Data;
using EmployeeApi.Interfaces;
using EmployeeApi.Options;
using EmployeeApi.Repositories;
using EmployeeApi.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeeApi.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEmployeeDI(this IServiceCollection services, IConfiguration configuration)
        {
              services.Configure<ConnectionStringOptions>(configuration.GetSection(ConnectionStringOptions.SectionName));
            services.AddDbContext<AppDbContext>((provider, options) =>{
                options.UseNpgsql(provider.GetRequiredService<IOptionsSnapshot<ConnectionStringOptions>>().Value.DefaultConnection);
            });
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();
            services.AddTransient<IPostHttpClientService, PostHttpClientService>();
            services.AddHttpClient<IPostHttpClientService, PostHttpClientService>(option =>
            {
                option.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            });

            services.AddHttpClient<IJokeHttpClientService, JokeHttpClientService>(option =>
            {
                option.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
            });
              services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            return services;
        }
    }
}