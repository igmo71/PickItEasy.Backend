using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain;

namespace PickItEasy.Persistence.EntityTypeConfigurations
{
    public class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.HasIndex(o => o.Id).IsUnique();

            builder.HasOne(o => o.OrderStatus).WithMany()
                .HasForeignKey(o => o.OrderStatusId).HasPrincipalKey(os => os.Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(o => o.OrderQueue).WithMany()
                .HasForeignKey(o => o.OrderQueueId).HasPrincipalKey(oq => oq.Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(o => o.OrderDetails).WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId).HasPrincipalKey(o => o.Id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.Number).HasMaxLength(36);
        }
    }
}
