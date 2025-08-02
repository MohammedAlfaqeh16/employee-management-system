using asp.netCore_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace asp.netCore_project.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }

        // Define DbSets for your entities here
        // public DbSet<YourEntity> YourEntities { get; set; }
        public DbSet<items> items { get; set; }
        public DbSet<Category> categories { get; set; }

        public DbSet<Employee> Employees { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(

                new Category() { Id = 1, Name = "select Category" },
                new Category() { Id = 2, Name = "computers" },
                new Category() { Id = 3, Name = "MObiles" },
                new Category() { Id = 4, Name = "Electric Machines" },
                new Category() { Id = 5, Name = "Others" }
                );

            modelBuilder.Entity<IdentityRole>().HasData(
    new IdentityRole()
    {
        Id = "1A2B3C4D-0000-1111-2222-1234567890AB",
        Name = "Admin",
        NormalizedName = "ADMIN", // الأفضل كتابة الأحرف الكبيرة
        ConcurrencyStamp = "ABC12345-6789-0000-1111-222233334444"
    },
    new IdentityRole()
    {
        Id = "5E6F7G8H-9999-8888-7777-9876543210CD",
        Name = "User",
        NormalizedName = "USER",
        ConcurrencyStamp = "DDD55555-6666-7777-8888-99990000AAAA"
    }
);

            base.OnModelCreating(modelBuilder);
        }
    }
    
    
}
