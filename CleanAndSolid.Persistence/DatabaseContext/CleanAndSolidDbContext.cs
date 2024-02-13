using CleanAndSolid.Domain;
using CleanAndSolid.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace CleanAndSolid.Persistence.DatabaseContext
{
    public class CleanAndSolidDbContext : DbContext
    {
        public CleanAndSolidDbContext(DbContextOptions<CleanAndSolidDbContext> options) : base(options)
        {
            
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        //On définit le comportement par défaut des entités (toutes les entités qui héritent de BaseEntity).
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.Now;
                if(entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        //Seed the database.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Applique toutes les configurations définies dans cette dll (cf. dossier configurations).
            //Equivalent à : 
            //modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
            //mais il faudrait le faire pour chaque configuration.
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanAndSolidDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
            
        }
    }
}
