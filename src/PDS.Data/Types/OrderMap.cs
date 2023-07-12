using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {

        public void Configure(EntityTypeBuilder<Order> builder)
        {

            builder.ToTable("order");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Price).HasColumnName("price");
            builder.Property(i => i.Price).IsRequired();

            builder.Property(i => i.Amount).HasColumnName("amount");
            builder.Property(i => i.Amount).IsRequired();

            builder.Property(i => i.OrderSplittedId).HasColumnName("order_splitted_id");
            builder.Property(i => i.OrderSplittedId).IsRequired();

            builder.Property(i => i.ProductRouteId).HasColumnName("product_route_id");
            builder.Property(i => i.ProductRouteId).IsRequired();

            builder.Property(i => i.Response).HasColumnName("response");
            builder.Property(i => i.Response).IsRequired();

            builder.Property(i => i.TimeToAnswer).HasColumnName("time_to_answer");
            builder.Property(i => i.TimeToAnswer).IsRequired();


        }
    }
}
