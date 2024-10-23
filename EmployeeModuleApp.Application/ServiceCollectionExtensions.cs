using Common.Core.Behaviours;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeModuleApp.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection serviceCollection)
        {
            //name asan uzerinde
            serviceCollection.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
                configuration.AddOpenBehavior(typeof(LoggingPipelineBehaviour<,>));
                configuration.AddOpenBehavior(typeof(ValidationiPipelineBehaviour<,>));
                //logging yazib burda
            });
            serviceCollection.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);
            return serviceCollection;
        }
    }
}
