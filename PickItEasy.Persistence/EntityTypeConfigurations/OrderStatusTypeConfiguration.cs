using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain;

namespace PickItEasy.Persistence.EntityTypeConfigurations
{
    public class OrderStatusTypeConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.Id);
            builder.HasIndex(os => os.Id).IsUnique();
            builder.Property(os => os.Name).HasMaxLength(36);
        }
    }
}
