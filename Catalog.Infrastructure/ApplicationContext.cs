using Catalog.Application.Interfaces;
using Catalog.Domain.Common.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure
{
    public class ApplicationContext : DbContext, IUnitOfWork
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.DetectChanges();

            foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        //TODO : Get user id from _currentUserService
                        entry.Entity.CreatedBy = "";// _currentUserService.GetUserId();
                        entry.Entity.CreatedOn = DateTime.Now;
                        break;

                    case EntityState.Modified:
                    case EntityState.Deleted:
                        //TODO : Get user id from _currentUserService
                        entry.Entity.UpdatedBy = "";// _currentUserService.GetUserId();
                        entry.Entity.UpdatedOn = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}