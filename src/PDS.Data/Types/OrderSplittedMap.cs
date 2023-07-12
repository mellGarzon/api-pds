using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
    public class OrderSplittedMap : IEntityTypeConfiguration<OrderSplitted>
    {

        public void Configure(EntityTypeBuilder<OrderSplitted> builder)
        {

            builder.ToTable("order_splitted");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.ClientId).HasColumnName("client_id");
            builder.Property(i => i.ClientId).IsRequired();

            builder.Property(i => i.AgriculturalProducerId).HasColumnName("agricultural_producer_id");
            builder.Property(i => i.AgriculturalProducerId).IsRequired();


        }
    }
}
