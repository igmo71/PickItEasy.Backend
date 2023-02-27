using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PickItEasy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence.EntityTypeConfigurations
{
    public class OrderDetailTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();
            builder.HasOne(od => od.Order).WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId).HasPrincipalKey(o => o.Id)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(od => od.Product).WithMany()
                .HasForeignKey(od => od.ProductId).HasPrincipalKey(o => o.Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
