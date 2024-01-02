

using Application.Behaviours.User;
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

            ValidatorOptions.Global.LanguageManager = new ValidatorFluentCustomLanguage();

            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<ICarRepository,CarRepository>();

            services.AddMediatR(Options =>
            {
                Options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            }).AddScoped(typeof(IPipelineBehavior<,>), typeof(UserValidationBehaviour<,>))
            .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));


            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddHttpContextAccessor();

            services.AddTransient((typeof(IGenericRepository<>)),(typeof(GenericRepository<>)));

            return services;
        }
    }
}
