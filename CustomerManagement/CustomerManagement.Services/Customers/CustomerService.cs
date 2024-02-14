using CustomerManagement.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Services.Customers
{
    internal class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomerAsync(NewCustomerDto customer)
        {
            await _customerRepository.AddAsync(new Customer(customer.FirstName, customer.LastName, customer.Email));
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            return (await _customerRepository.GetAllAsync()).Select(x => 
                 new CustomerDto()
                 {
                     Id = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Email = x.Email,
                     DateCreated = x.DateCreated,
                     DateUpdated = x.DateUpdated,
                 });
        }

        public async Task<CustomerDto?> GetCustomerByIdAsync(int id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if(customer == null)
            {
                return null;
            }

            return new CustomerDto()
            {

                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                DateCreated = customer.DateCreated,
                DateUpdated = customer.DateUpdated,
            };
        }

        public async Task UpdateCustomerAsync(CustomerUpdateDto customer)
        {
            await _customerRepository.UpdateAsync(
                new Customer(customer.Id, customer.FirstName, customer.LastName, customer.Email));
        }
    }
}
