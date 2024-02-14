namespace CustomerManagement.Domain.Customers
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set;}

        public Customer(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateCreated = DateTime.UtcNow;
        }

        public Customer(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateCreated = DateTime.UtcNow;
        }

        private Customer() { }
    }
}
