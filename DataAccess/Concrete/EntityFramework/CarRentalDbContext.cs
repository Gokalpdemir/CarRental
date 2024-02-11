using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CarRentalDb;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

        public override int SaveChanges()
        {
            this.SetAddedEntities(GetAddedEntities());
            this.SetUpdatedEntities(GetUpdatedEntities());
            this.SetDeletedEntities(GetDeletedEntities());

            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        private List<IEntity> GetEntititesByEntityState(EntityState entityState)
        {
            return ChangeTracker.Entries<IEntity>().Where(e => e.State == entityState).Select(e => e.Entity).ToList();

        }

        private List<IEntity> GetAddedEntities()
        {
            return this.GetEntititesByEntityState(EntityState.Added);
        }

        private List<IEntity> GetUpdatedEntities()
        {
            List<IEntity> addedEntityList = ChangeTracker.Entries<IEntity>().Where(e => e.State == EntityState.Modified).Select(e => e.Entity).ToList();

            return addedEntityList;
        }

        private List<IEntity> GetDeletedEntities()
        {
            List<IEntity> addedEntityList = ChangeTracker.Entries<IEntity>().Where(e => e.State == EntityState.Deleted).Select(e => e.Entity).ToList();

            return addedEntityList;
        }

        private void SetAddedEntities(List<IEntity> addedEntities)
        {
            foreach (var entity in addedEntities)
            {
                entity.CreatedDate = DateTime.Now;
            }
        }

        private void SetUpdatedEntities(List<IEntity> addedEntities)
        {
            foreach (var entity in addedEntities)
            {
                entity.UpdatedDate = DateTime.Now;
            }
        }

        private void SetDeletedEntities(List<IEntity> addedEntities)
        {
            foreach (var entity in addedEntities)
            {
                entity.DeletedDate = DateTime.Now;
            }
        }
    }
}
