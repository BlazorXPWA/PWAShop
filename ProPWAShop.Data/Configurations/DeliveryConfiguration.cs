namespace ProPWAShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    internal class DeliveryConfiguration : IEntityTypeConfiguration<Delivery>
    {
        public void Configure(EntityTypeBuilder<Delivery> order)
        {
            order
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
        }
    }
}