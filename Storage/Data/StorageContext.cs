using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace Storage
{
    public class StorageContext : DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}