﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PDS.Data.Context;

#nullable disable

namespace PDS.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PDS.Domain.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint")
                        .HasColumnName("client_id");

                    b.Property<string>("Completion")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("completion");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("neighborhood");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("reference");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("street_name");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("address", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.AgriculturalProducer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<long>("MediaId")
                        .HasColumnType("bigint")
                        .HasColumnName("media_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_salt");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("agricultural_producer", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<long>("MediaId")
                        .HasColumnType("bigint")
                        .HasColumnName("media_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_salt");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("client", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.Media", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.ToTable("media", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<long?>("OrderSplittedId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("order_splitted_id");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.Property<long?>("ProductRouteId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("product_route_id");

                    b.Property<bool>("Response")
                        .HasColumnType("boolean")
                        .HasColumnName("response");

                    b.Property<DateTime>("TimeToAnswer")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("time_to_answer");

                    b.HasKey("Id");

                    b.HasIndex("OrderSplittedId");

                    b.HasIndex("ProductRouteId");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.OrderSplitted", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AgriculturalProducerId")
                        .HasColumnType("bigint")
                        .HasColumnName("agricultural_producer_id");

                    b.Property<long>("ClientId")
                        .HasColumnType("bigint")
                        .HasColumnName("client_id");

                    b.HasKey("Id");

                    b.HasIndex("AgriculturalProducerId");

                    b.HasIndex("ClientId");

                    b.ToTable("order_splitted", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AgriculturalProducerId")
                        .HasColumnType("bigint")
                        .HasColumnName("agricultural_producer_id");

                    b.Property<int>("Amount")
                        .HasColumnType("integer")
                        .HasColumnName("amount");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("image_url");

                    b.Property<long>("MediaId")
                        .HasColumnType("bigint")
                        .HasColumnName("media_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("AgriculturalProducerId");

                    b.HasIndex("MediaId");

                    b.ToTable("product", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.ProductRoute", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("ProductId")
                        .HasColumnType("bigint")
                        .HasColumnName("product_id");

                    b.Property<long>("RouteId")
                        .HasColumnType("bigint")
                        .HasColumnName("route_id");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("RouteId");

                    b.ToTable("product_route", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.Route", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("AgriculturalProducerId")
                        .IsRequired()
                        .HasColumnType("bigint")
                        .HasColumnName("agricultural_producer_id");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cep");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("delivery_date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("uf");

                    b.HasKey("Id");

                    b.HasIndex("AgriculturalProducerId");

                    b.ToTable("route", (string)null);
                });

            modelBuilder.Entity("PDS.Domain.Entities.Address", b =>
                {
                    b.HasOne("PDS.Domain.Entities.Client", "Client")
                        .WithMany("Adresses")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("PDS.Domain.Entities.AgriculturalProducer", b =>
                {
                    b.HasOne("PDS.Domain.Entities.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");
                });

            modelBuilder.Entity("PDS.Domain.Entities.Client", b =>
                {
                    b.HasOne("PDS.Domain.Entities.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Media");
                });

            modelBuilder.Entity("PDS.Domain.Entities.Order", b =>
                {
                    b.HasOne("PDS.Domain.Entities.OrderSplitted", "OrderSplitted")
                        .WithMany("Orders")
                        .HasForeignKey("OrderSplittedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PDS.Domain.Entities.ProductRoute", "ProductRoute")
                        .WithMany("Orders")
                        .HasForeignKey("ProductRouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderSplitted");

                    b.Navigation("ProductRoute");
                });

            modelBuilder.Entity("PDS.Domain.Entities.OrderSplitted", b =>
                {
                    b.HasOne("PDS.Domain.Entities.AgriculturalProducer", "AgriculturalProducer")
                        .WithMany("OrdersSplitted")
                        .HasForeignKey("AgriculturalProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PDS.Domain.Entities.Client", "Client")
                        .WithMany("OrdersSplitted")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgriculturalProducer");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("PDS.Domain.Entities.Product", b =>
                {
                    b.HasOne("PDS.Domain.Entities.AgriculturalProducer", "AgriculturalProducer")
                        .WithMany("Products")
                        .HasForeignKey("AgriculturalProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PDS.Domain.Entities.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgriculturalProducer");

                    b.Navigation("Media");
                });

            modelBuilder.Entity("PDS.Domain.Entities.ProductRoute", b =>
                {
                    b.HasOne("PDS.Domain.Entities.Product", "Product")
                        .WithMany("ProductRoutes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PDS.Domain.Entities.Route", "Route")
                        .WithMany("ProductRoutes")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("PDS.Domain.Entities.Route", b =>
                {
                    b.HasOne("PDS.Domain.Entities.AgriculturalProducer", "AgriculturalProducer")
                        .WithMany("Routes")
                        .HasForeignKey("AgriculturalProducerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AgriculturalProducer");
                });

            modelBuilder.Entity("PDS.Domain.Entities.AgriculturalProducer", b =>
                {
                    b.Navigation("OrdersSplitted");

                    b.Navigation("Products");

                    b.Navigation("Routes");
                });

            modelBuilder.Entity("PDS.Domain.Entities.Client", b =>
                {
                    b.Navigation("Adresses");

                    b.Navigation("OrdersSplitted");
                });

            modelBuilder.Entity("PDS.Domain.Entities.OrderSplitted", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PDS.Domain.Entities.Product", b =>
                {
                    b.Navigation("ProductRoutes");
                });

            modelBuilder.Entity("PDS.Domain.Entities.ProductRoute", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PDS.Domain.Entities.Route", b =>
                {
                    b.Navigation("ProductRoutes");
                });
#pragma warning restore 612, 618
        }
    }
}
