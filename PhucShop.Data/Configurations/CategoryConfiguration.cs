using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhucShop.Data.Entities;
using PhucShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhucShop.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Status).HasDefaultValue(Status.Active);
            builder.Property(x => x.Id).UseIdentityColumn();
        }
    }
}
