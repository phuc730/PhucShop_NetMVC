using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhucShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Data.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetails");

            builder.HasKey(x => new { x.OrderId, x.ProductId });

            builder.HasOne(x => x.Product).WithMany(y => y.OrderDetails).HasForeignKey(z => z.ProductId);
            builder.HasOne(x => x.Order).WithMany(y => y.OrderDetails).HasForeignKey(z => z.OrderId);
        }
    }
}
