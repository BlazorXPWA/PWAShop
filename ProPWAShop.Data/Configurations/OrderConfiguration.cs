namespace ProPWAShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> order)
        {
            //order
            //    .HasOne(o => o.User)
            //    .WithMany(u => u.Orders)
            //    .HasForeignKey(o => o.UserId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Restrict);

            //order
            //    .HasOne(o => o.DeliveryAddress)
            //    .WithMany(a => a.Orders)
            //    .HasForeignKey(o => o.DeliveryAddressId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //order
            //    .HasOne(o => o.Delivery)
            //    .WithMany(a => a.Orders)
            //    .HasForeignKey(o => o.DeliveryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            order
                .Property(p => p.OrderPrice)
                .HasColumnType("decimal(18,2)");
        }
    }
}