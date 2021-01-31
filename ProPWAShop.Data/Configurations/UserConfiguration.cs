namespace ProPWAShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstants.Common;

    internal class UserConfiguration : IEntityTypeConfiguration<ProPWAShopUser>
    {
        public void Configure(EntityTypeBuilder<ProPWAShopUser> user)
        {
            user
                .Property(u => u.FirstName)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            user
                .Property(u => u.LastName)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            user
                .HasIndex(u => u.IsDeleted);

            user
                .HasQueryFilter(u => !u.IsDeleted);
        }
    }
}
