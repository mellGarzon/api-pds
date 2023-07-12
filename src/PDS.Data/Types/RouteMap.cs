using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
    public class RouteMap : IEntityTypeConfiguration<Route>
    {

        public void Configure(EntityTypeBuilder<Route> builder)
        {

            builder.ToTable("route");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name).HasColumnName("name");
            builder.Property(i => i.Name).IsRequired();

            builder.Property(i => i.City).HasColumnName("city");
            builder.Property(i => i.City).IsRequired();

            builder.Property(i => i.Uf).HasColumnName("uf");
            builder.Property(i => i.Uf).IsRequired();

            builder.Property(i => i.Cep).HasColumnName("cep");
            builder.Property(i => i.Cep).IsRequired();

            builder.Property(i => i.AgriculturalProducerId).HasColumnName("agricultural_producer_id");
            builder.Property(i => i.AgriculturalProducerId).IsRequired();

            builder.Property(i => i.DeliveryDate).HasColumnName("delivery_date");
            builder.Property(i => i.DeliveryDate).IsRequired().HasColumnType("timestamp without time zone");


        }
    }
}


