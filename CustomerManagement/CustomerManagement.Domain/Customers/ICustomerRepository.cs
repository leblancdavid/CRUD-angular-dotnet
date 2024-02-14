using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Customers
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(Customer customer);
        Task<Customer> AddAsync(Customer customer);    
    }
}
