using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.ToTable("product");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name).HasColumnName("name");
            builder.Property(i => i.Name).IsRequired();

            builder.Property(i => i.ImageUrl).HasColumnName("image_url");
            builder.Property(i => i.ImageUrl).IsRequired();

            builder.Property(i => i.Price).HasColumnName("price");
            builder.Property(i => i.Price).IsRequired();

            builder.Property(i => i.AgriculturalProducerId).HasColumnName("agricultural_producer_id");
            builder.Property(i => i.AgriculturalProducerId).IsRequired();

            builder.Property(i => i.Amount).HasColumnName("amount");
            builder.Property(i => i.Amount).IsRequired();

            builder.Property(i => i.Description).HasColumnName("description");
            builder.Property(i => i.Description).IsRequired();

            builder.Property(i => i.MediaId).HasColumnName("media_id");
            builder.Property(i => i.MediaId).IsRequired();


        }
    }
}
