﻿using BlazorRepository.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorRepository.Configuration
{
    public class ProductConfiguration : EntityBaseConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ExpiredDate).HasColumnType("datetime");
        }
    }
}
