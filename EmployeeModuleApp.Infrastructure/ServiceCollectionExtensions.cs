using EmployeeModule.Domain.Employees.DomainServices;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeModuleApp.Infrastructure
{
    //proxy,client,service,api(implement)
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddTransient<IPassportService, AsanPassportService>();
        }
    }
}
