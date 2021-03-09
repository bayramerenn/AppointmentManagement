using AppointmentManagement.UI.Entity.CustomEntity;
using CivilManagement.UI.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Identity.Context
{
    public class AppIdentityDbContext:IdentityDbContext<AppUser,AppRole,string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options):base(options)
        {

        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<CustomAppointment> CustomAppointments{ get; set; }
        public DbSet<CustomApprovedPlugs> CustomApprovedPlugs{ get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CustomAppointment>(eb => eb.HasNoKey());
        //    modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserLogin<string>>(eb => eb.HasKey(key => key.UserId));
        //    modelBuilder.Entity<Microsoft.AspNetCore.Identity.IdentityUserRole<string>>(eb => eb.HasKey(key => key.RoleId));
        //}
  
    }
}
