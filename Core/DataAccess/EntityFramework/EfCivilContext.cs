using AppointmentManagement.Entities.Concrete;
using AppointmentManagement.Entities.Concrete.FromSqlRaw;
using AppointmentManagement.Entities.Concrete.Procedure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Core.DataAccess.EntityFramework
{
    public class EfCivilContext : DbContext
    {
        public EfCivilContext(DbContextOptions<EfCivilContext> options) : base(options)
        {

        }


        public DbSet<VehicleTypes> VehicleTypes { get; set; }
        public DbSet<PostedType> PostedTypes { get; set; }
        public DbSet<OrderWarehouse> OrderWarehouses { get; set; }
        public DbSet<trOrderAsnHeader> trOrderAsnHeader{ get; set; }
        public DbSet<cdCurrAccDesc> cdCurrAccDesc { get; set; }
        public DbSet<OrderHeaderInfo> OrderHeaderInfo { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<uspGetVendorOrders>(eb => eb.HasNoKey());
            modelBuilder.Entity<OrderWarehouse>(eb => eb.HasNoKey());
            modelBuilder.Entity<uspGetVendorOrderLine>(eb => eb.HasNoKey());
            modelBuilder.Entity<uspCreateOrderAsnHeader>(eb => eb.HasNoKey());
            modelBuilder.Entity<uspCreateOrderAsnLine>(eb =>eb.HasNoKey());
            modelBuilder.Entity<uspGetOrderAsn>(eb =>eb.HasNoKey());
            modelBuilder.Entity<uspGetOrderAsnLine>(eb =>eb.HasNoKey());
            modelBuilder.Entity<uspGetOrderAsnLineToOrderHeaderId>(eb =>eb.HasNoKey());
            modelBuilder.Entity<cdCurrAccDesc>(eb =>eb.HasNoKey());
            modelBuilder.Entity<OrderHeaderInfo>(eb =>eb.HasNoKey());
          
        }
    }
}
