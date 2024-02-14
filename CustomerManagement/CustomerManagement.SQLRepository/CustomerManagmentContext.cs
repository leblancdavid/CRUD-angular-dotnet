using CustomerManagement.Domain.Customers;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.SQLRepository
{
    public class CustomerManagmentContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        public CustomerManagmentContext(DbContextOptions options)
           : base(options)
        { }

        public CustomerManagmentContext()
        { }
    }
}
