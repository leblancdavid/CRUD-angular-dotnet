using CustomerManagement.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net.Mime;

namespace CustomerManagement.SQLRepository.Customers
{
    public class CustomerEfRepository : ICustomerRepository
    {
        private readonly DbContextOptions<CustomerManagmentContext> _dbContextOptions;
        private readonly ILogger<CustomerEfRepository> _logger;

        public CustomerEfRepository(DbContextOptions<CustomerManagmentContext> dbContextOptions,
            ILogger<CustomerEfRepository> logger)
        {
            _dbContextOptions = dbContextOptions;
            _logger = logger;
        }

        public async Task AddAsync(Customer customer)
        {
            try
            {
                var context = new CustomerManagmentContext(_dbContextOptions);

                customer.DateCreated = DateTime.UtcNow;

                await context.AddAsync(customer);

                await context.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex , ex.Message);
                throw;
            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var context = new CustomerManagmentContext(_dbContextOptions);

                var customerToRemove = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
                if (customerToRemove != null)
                {
                    context.Customers.Remove(customerToRemove);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var context = new CustomerManagmentContext(_dbContextOptions);
            return context.Customers;
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            var context = new CustomerManagmentContext(_dbContextOptions);
            return await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Customer customer)
        {
            try
            {
                var context = new CustomerManagmentContext(_dbContextOptions);

                var customerToUpdate = await context.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id);
                if (customerToUpdate == null)
                {
                    throw new Exception($"Customer with id {customer.Id} does not exist");
                }

                customerToUpdate.FirstName = customer.FirstName;
                customerToUpdate.LastName = customer.LastName;
                customerToUpdate.Email = customer.Email;
                customerToUpdate.DateUpdated = DateTime.UtcNow;

                context.Customers.Update(customerToUpdate);

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
