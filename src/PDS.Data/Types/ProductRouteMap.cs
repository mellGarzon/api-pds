using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
    public class ProductRouteMap : IEntityTypeConfiguration<ProductRoute>
    {

        public void Configure(EntityTypeBuilder<ProductRoute> builder)
        {

            builder.ToTable("product_route");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ProductId).HasColumnName("product_id");
            builder.Property(i => i.ProductId).IsRequired();

            builder.Property(i => i.RouteId).HasColumnName("route_id");
            builder.Property(i => i.RouteId).IsRequired();

        }
    }
}

