using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        
        }

        public DbSet<Company> COMPANY { get; set; }
        public DbSet<Asset> ASSETS { get; set; }
        public DbSet<InspectionClass> INSPECTIONCLASS { get; set; }
        public DbSet<InspectionHeader> INSPECTIONHEADER { get; set; }
        public DbSet<InspectionLine> INSPECTIONLINE { get; set; }
        public DbSet<Inspections> INSPECTIONS { get; set; }
        public DbSet<InspectionType> INSPECTIONTYPE { get; set; }
        public DbSet<Project> PROJECT { get; set; }
        public DbSet<ProjectSettings> PROJECTSETTINGS { get; set; }
        public DbSet<Role> ROLE { get; set; }
        public DbSet<User> USER { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.Latitude).HasPrecision(10, 8);
                entity.Property(e => e.Longitude).HasPrecision(11, 8);
            });
            modelBuilder.Entity<InspectionHeader>(entity =>
            {
                entity.Property(e => e.Latitude).HasPrecision(10, 8);
                entity.Property(e => e.Longitude).HasPrecision(11, 8);
            });
            // Configure other entities as needed
        }
    }
}
