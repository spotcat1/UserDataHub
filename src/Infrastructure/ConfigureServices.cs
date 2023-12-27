

using Application.Contracts;
using FluentValidation;
using Infrastructure.CrossCutting.Validations.UserValidation;
using Infrastructure.Persistants;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options=>options.UseSqlServer(configuration.GetConnectionString("UserDataHubConnectionString")));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            ValidatorOptions.Global.LanguageManager = new UserValidatorFluentCustomLanguage();

            services.AddScoped<IUserRepository,UserRepository>();

            services.AddMediatR(Options =>
            {
                Options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
