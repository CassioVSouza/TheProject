using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using The_Project.Domain.Entities;

namespace The_Project.Infrastructure.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        } 

        public DbSet<ScheduleEntity> Schedule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleEntity>(schedule =>
            {
                schedule.Property(p => p.Name)
                        .IsRequired();
                schedule.Property(p => p.Description)
                        .IsRequired();
            });
        }
    }
}
