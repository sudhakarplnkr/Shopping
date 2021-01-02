namespace Inventory.WebApiDbContext
{
    using Inventory.WebApi.Data.Entity;
    using Microsoft.EntityFrameworkCore;

    public class InventoryContext : DbContext
    {
        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}