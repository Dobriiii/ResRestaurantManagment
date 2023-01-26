using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResRestaurantManagment.Data;

namespace ResRestaurantManagment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ResList>()
            .HasMany(rsr => rsr.Tables)
            .WithOne(rst => rst.ResList)
            .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(builder);
        }
        public DbSet<ResRestaurantManagment.Data.ResList> ResList { get; set; }
        public DbSet<ResRestaurantManagment.Data.ResTable> ResTable { get; set; }
    }
}