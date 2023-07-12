using System;
using Microsoft.EntityFrameworkCore.Migrations;
using PDS.Data.Context;
using static PDS.Data.Repositories.UnitOfWork;
using System.Net.NetworkInformation;
using PDS.Domain.Interfaces;

namespace PDS.Data.Repositories
{
	public class UnitOfWork : IUnitOfWork
    {

            private readonly DataContext _context;
            public UnitOfWork(DataContext context)
            {
                this._context = context;
            }

            public async Task CommitAsync()
            {
                await _context.SaveChangesAsync();

            }

        //public IAddressRepository AdressRepository
        //{
        //    get { return _AddressRepository ??= new AddressRepository(_context); }
        //}

        IAddressRepository IUnitOfWork.AddressRepository => throw new NotImplementedException();


        private IAgriculturalProducerRepository _AgriculturalProducerRepository;

        private IClientRepository _ClientRepository;

        private IOrderRepository _OrderRepository;

        private IOrderSplittedRepository _OrderSplittedRepository;

        private IProductRepository _ProductRepository;

        private IProductRouteRepository _ProductRouteRepository;

        private IRouteRepository _RouteRepository;

        public IAgriculturalProducerRepository AgriculturalProducerRepository
        {
            get { return _AgriculturalProducerRepository ??= new AgriculturalProducerRepository(_context); }
        }

        public IClientRepository ClientRepository
        {
            get { return _ClientRepository ??= new ClientRepository(_context); }
        }

        public IOrderRepository OrderRepository
        {
            get { return _OrderRepository ??= new OrderRepository(_context); }
        }

        public IOrderSplittedRepository OrderSplittedRepository
        {
            get { return _OrderSplittedRepository ??= new OrderSplittedRepository(_context); }
        }

        public IProductRepository ProductRepository
        {
            get { return _ProductRepository ??= new ProductRepository(_context); }
        }

        public IProductRouteRepository ProductRouteRepository
        {
            get { return _ProductRouteRepository ??= new ProductRouteRepository(_context); }
        }

        public IRouteRepository RouteRepository
        {
            get { return _RouteRepository ??= new RouteRepository(_context); }
        }
    }

}

