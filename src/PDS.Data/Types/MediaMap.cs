using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PDS.Domain.Entities;

namespace PDS.WebApi.Mappings
{
    public class MediaMap : IEntityTypeConfiguration<Media>
    {

        public void Configure(EntityTypeBuilder<Media> builder)
        {

            builder.ToTable("media");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Name).HasColumnName("name");
            builder.Property(i => i.Name).IsRequired();

            builder.Property(i => i.Path).HasColumnName("path");
            builder.Property(i => i.Path).IsRequired();
        }
    }
}
