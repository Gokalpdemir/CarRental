//using Core.Entities.Concrete;
//using Entities.Concrete;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace DataAccess.Concrete.Configurations;

//public class AppUserOperationClaimEntityConfiguration : IEntityTypeConfiguration<AppUserOperationClaim>
//{
//    public void Configure(EntityTypeBuilder<AppUserOperationClaim> builder)
//    {
//        builder.ToTable("AppUserOperationClaims")
//               .HasBaseType<UserOperationClaim>();

//        builder.HasKey(aoc => aoc.Id);

//        builder.Property(aoc => aoc.Id).HasColumnName("Id");
//        builder.Property(aoc => aoc.CreatedDate).HasColumnName("CreatedDate");
//        builder.Property(aoc => aoc.UpdatedDate).HasColumnName("UpdatedDate");
//        builder.Property(aoc => aoc.DeletedDate).HasColumnName("DeletedDate");

//        builder.HasOne(e => e.UserBase).WithMany(e => (ICollection<AppUserOperationClaim>)e.UserOperationClaimBases).HasForeignKey(e => e.UserBaseId);
//        builder.HasOne(e => e.OperationClaimBase).WithMany(e => (ICollection<AppUserOperationClaim>)e.UserOperationClaimBases).HasForeignKey(e => e.OperationClaimBaseId);
//    }
//}
