using Microsoft.EntityFrameworkCore;
using RegistroVotantes.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RegistroVotantes.Infrastructure
{
    public class PersistenceContext : DbContext
    {
        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options)
        {
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync().ConfigureAwait(false);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
            {
                return;
            }

            modelBuilder.Entity<Votante>();

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var t = entityType.ClrType;
                if (typeof(DomainEntity).IsAssignableFrom(t))
                {
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("CreatedOn").HasDefaultValueSql("GETDATE()");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("LastModifiedOn").HasDefaultValueSql("GETDATE()");
                }
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}