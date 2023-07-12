using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {

        public void Configure(EntityTypeBuilder<Address> builder)
        {

            builder.ToTable("address");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Neighborhood).HasColumnName("neighborhood");
            builder.Property(i => i.Neighborhood).IsRequired();

            builder.Property(i => i.Number).HasColumnName("number");
            builder.Property(i => i.Number).IsRequired();

            builder.Property(i => i.StreetName).HasColumnName("street_name");
            builder.Property(i => i.StreetName).IsRequired();

            builder.Property(i => i.Reference).HasColumnName("reference");
            builder.Property(i => i.Reference).IsRequired();

            builder.Property(i => i.Uf).HasColumnName("uf");
            builder.Property(i => i.Uf).IsRequired();

            builder.Property(i => i.City).HasColumnName("city");
            builder.Property(i => i.City).IsRequired();

            builder.Property(i => i.Cep).HasColumnName("cep");
            builder.Property(i => i.Cep).IsRequired();

            builder.Property(i => i.Completion).HasColumnName("completion");
            builder.Property(i => i.Completion).IsRequired();

            builder.Property(i => i.ClientId).HasColumnName("client_id");
            builder.Property(i => i.ClientId).IsRequired();

        }
    }
}
