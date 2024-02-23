using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Configurations;

public class AppOperationClaimEntityConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    //public void Configure(EntityTypeBuilder<OperationClaim> builder)
    //{
    //    builder.ToTable("AppOperationClaims")
    //           .HasBaseType<OperationClaim>();

    //    builder.HasKey(aoc => aoc.Id);

    //    builder.Property(aoc => aoc.Id).HasColumnName("Id");
    //    builder.Property(aoc => aoc.Name).HasColumnName("Name");
    //    builder.Property(aoc => aoc.CreatedDate).HasColumnName("CreatedDate");
    //    builder.Property(aoc => aoc.UpdatedDate).HasColumnName("UpdatedDate");
    //    builder.Property(aoc => aoc.DeletedDate).HasColumnName("DeletedDate");

    //    builder.HasMany(aoc => aoc.UserOperationClaims);
    //}
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        throw new NotImplementedException();
    }
}
