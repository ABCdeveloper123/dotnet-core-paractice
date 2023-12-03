using _2nd.Model;
using Microsoft.EntityFrameworkCore;

namespace _2nd.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { 
        
        
        }

        public DbSet<Coupon> coupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }




    }
}
