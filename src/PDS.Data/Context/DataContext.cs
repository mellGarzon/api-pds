using PDS.Domain.Entities;
using PDS.WebApi.Mappings;
using System;
using Microsoft.EntityFrameworkCore;

namespace PDS.Data.Context
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions options) : base(options){ }

        public DbSet<Address> Adresses { get; set; }

        public DbSet<AgriculturalProducer> AgriculturalProducers { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderSplitted> OrdersSplitted { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductRoute> ProductRoutes { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Media> Media { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new AgriculturalProducerMap());
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new OrderMap());
            modelBuilder.ApplyConfiguration(new OrderSplittedMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ProductRouteMap());
            modelBuilder.ApplyConfiguration(new RouteMap());
            modelBuilder.ApplyConfiguration(new MediaMap());

        }

        

    }
}

