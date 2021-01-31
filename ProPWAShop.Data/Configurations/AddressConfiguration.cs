namespace ProPWAShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    using static ModelConstants.Address;

    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> address)
        {
            address
                .Property(a => a.Comments)
                .HasMaxLength(MaxCommentLength);

            address
                .Property(a => a.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired();

          

            address
                .Property(a => a.PhoneNumber)
                .HasMaxLength(MaxPhoneNumberLength)
                .IsRequired();

            address
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            address
                .HasIndex(a => a.IsDeleted);

            address
                .HasQueryFilter(a => !a.IsDeleted);
        }
    }
}