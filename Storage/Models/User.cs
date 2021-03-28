using Microsoft.AspNetCore.Identity;

namespace Storage.Models
{
    public class User
    {
        public int Id { get; set; }
        public int Age { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

        // public virtual Collection<Product> Products { get; set; }
        // public virtual Collection<Order> Orders { get; set; }
    }
}