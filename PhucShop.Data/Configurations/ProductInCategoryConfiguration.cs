using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhucShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Data.Configurations
{
    public class ProductInCategoryConfiguration : IEntityTypeConfiguration<ProductInCategory>
    {
        public void Configure(EntityTypeBuilder<ProductInCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId });

            builder.ToTable("ProductInCategories");
            //Config khoa ngoai
            builder.HasOne(x => x.Product).WithMany(y => y.ProductInCategories).HasForeignKey(z => z.ProductId);
            builder.HasOne(x => x.Category).WithMany(y => y.ProductInCategories).HasForeignKey(z => z.CategoryId);
        }
    }
}
