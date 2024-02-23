using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.Configurations;

public class AppUserEntityConfiguration : IEntityTypeConfiguration<User>
{
    //public void Configure(EntityTypeBuilder<AppUser> builder)
    //{
    //    builder.ToTable("AppUsers")
    //           .HasBaseType<UserBase>();

    //    builder.HasKey(aoc => aoc.Id);

    //    builder.Property(aoc => aoc.Id).HasColumnName("Id");
    //    builder.Property(aoc => aoc.CreatedDate).HasColumnName("CreatedDate");
    //    builder.Property(aoc => aoc.UpdatedDate).HasColumnName("UpdatedDate");
    //    builder.Property(aoc => aoc.DeletedDate).HasColumnName("DeletedDate");

    //    builder.HasMany(aoc => aoc.UserOperationClaimBases);
    //}
    public void Configure(EntityTypeBuilder<User> builder)
    {
        throw new NotImplementedException();
    }
}
