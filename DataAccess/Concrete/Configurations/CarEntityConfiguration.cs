using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configurations;

public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        throw new NotImplementedException();
        //builder.ToTable("Cars");

        //builder.HasKey(c => c.Id);

        //builder.Property(c => c.Id).HasColumnName("Id");
        //builder.Property(c => c.BrandId).HasColumnName("BrandId");
        //builder.Property(c => c.ColorId).HasColumnName("ColorId");
        //builder.Property(c => c.CarName).HasColumnName("CarName");
        //builder.Property(c => c.ModelYear).HasColumnName("ModelYear");
        //builder.Property(c => c.DailyPrice).HasColumnName("DailyPrice").HasColumnType("decimal");
        //builder.Property(c => c.Description).HasColumnName("Description");
        //builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate");
        //builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        //builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        //builder.HasOne(c => c.Brand);
        //builder.HasOne(c => c.Color);
        //builder.HasMany(c => c.Rentals);
        //builder.HasMany(c => c.CarImages);
    }
}
