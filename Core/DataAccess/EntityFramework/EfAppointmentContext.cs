using AppointmentManagement.Entities.Concrete.Procedure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentManagement.Core.DataAccess.EntityFramework
{
    public class EfAppointmentContext:DbContext
    {
        public EfAppointmentContext(DbContextOptions<EfAppointmentContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<uspGetVendorOrders>(eb => eb.HasNoKey());
        }
    }
}
