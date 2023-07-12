using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
    public class AgriculturalProducerMap : IEntityTypeConfiguration<AgriculturalProducer>
    {

        public void Configure(EntityTypeBuilder<AgriculturalProducer> builder)
        {

            builder.ToTable("agricultural_producer");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name).HasColumnName("name");
            builder.Property(i => i.Name).IsRequired();

            builder.Property(i => i.Email).HasColumnName("email");
            builder.Property(i => i.Email).IsRequired();

            builder.Property(i => i.PasswordHash).HasColumnName("password");
            builder.Property(i => i.PasswordHash).IsRequired();

            builder.Property(i => i.PasswordSalt).HasColumnName("password_salt");
            builder.Property(i => i.PasswordSalt).IsRequired();

            builder.Property(i => i.Phone).HasColumnName("phone");
            builder.Property(i => i.Phone).IsRequired();

            builder.Property(i => i.MediaId).HasColumnName("media_id");
            builder.Property(i => i.MediaId).IsRequired();

            builder.Property(i => i.ImageUrl).HasColumnName("image_url");
            builder.Property(i => i.ImageUrl).IsRequired();

            builder.Property(i => i.Role).HasColumnName("role");
            builder.Property(i => i.Role).IsRequired();
        }
    }
}

