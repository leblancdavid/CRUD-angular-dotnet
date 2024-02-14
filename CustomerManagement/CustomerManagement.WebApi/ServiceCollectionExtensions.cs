using CustomerManagement.Domain.Customers;
using CustomerManagement.Services.Customers;
using CustomerManagement.SQLRepository.Customers;
using System.Runtime.CompilerServices;

namespace CustomerManagement.WebApi
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerEfRepository>();

        }
    }
}
