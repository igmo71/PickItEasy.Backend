using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain;

namespace PickItEasy.Persistence.EntityTypeConfigurations
{
    public class OrderQueueTypeConfiguration : IEntityTypeConfiguration<OrderQueue>
    {
        public void Configure(EntityTypeBuilder<OrderQueue> builder)
        {
            builder.HasKey(oq => oq.Id);
            builder.HasIndex(oq => oq.Id).IsUnique();
            builder.Property(oq => oq.Name).HasMaxLength(36);
        }
    }
}
