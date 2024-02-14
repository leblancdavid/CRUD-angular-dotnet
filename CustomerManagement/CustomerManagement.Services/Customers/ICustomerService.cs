using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Services.Customers
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto?> GetCustomerByIdAsync(int id);
        Task DeleteCustomerAsync(int id);
        Task UpdateCustomerAsync(CustomerUpdateDto customer);
        Task AddCustomerAsync(NewCustomerDto customer);
    }
}
