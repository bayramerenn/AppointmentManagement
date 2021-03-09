using AppointmentManagement.Core.DataAccess.EntityFramework;
using AppointmentManagement.UI.Entity.Abstract;
using AppointmentManagement.UI.Entity.CustomEntity;
using AppointmentManagement.UI.Identity;
using AppointmentManagement.UI.Identity.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Entity.Concrete
{
    public class EfAppointment:EfEntityRepository<Appointment>,IAppointment
    {

        private AppIdentityDbContext _appContext { get => _context as AppIdentityDbContext; }
        public EfAppointment(AppIdentityDbContext context):base(context)
        {

        }

        public IList<CustomAppointment> GetRegisteredAppointment()
        {
            var result = _appContext.Set<CustomAppointment>()
                .FromSqlRaw("SELECT Appointments.Id,StartDate,EndDate,OrderAsnNumber,Appointments.Description,VendorDescription,Color,VehicleDesc,VehicleTypeId,Appointments.OrderAsnHeaderId,Appointments.VendorCode,UserId FROM dbo.Appointments WITH(NOLOCK) JOIN dbo.VehicleTypes WITH(NOLOCK)ON VehicleTypes.Id = Appointments.VehicleTypeId JOIN  Civil_Muhasebe..trOrderAsnHeader WITH(NOLOCK) ON trOrderAsnHeader.OrderAsnHeaderID = Appointments.OrderAsnHeaderId JOIN dbo.AspNetUsers WITH(NOLOCK) ON AspNetUsers.VendorCode = Appointments.VendorCode").ToList();

            return result;

        }

        public IList<CustomAppointment> GetRegisteredAppointmentByVehicleTypeId(int id)
        {
            var result = _appContext.Set<CustomAppointment>()
              .FromSqlRaw($"SELECT Appointments.Id,StartDate,EndDate,OrderAsnNumber,Appointments.Description,VendorDescription,Color,VehicleDesc,VehicleTypeId,Appointments.OrderAsnHeaderId,Appointments.VendorCode,UserId  FROM dbo.Appointments WITH(NOLOCK) JOIN dbo.VehicleTypes WITH(NOLOCK)ON VehicleTypes.Id = Appointments.VehicleTypeId JOIN  Civil_Muhasebe..trOrderAsnHeader WITH(NOLOCK) ON trOrderAsnHeader.OrderAsnHeaderID = Appointments.OrderAsnHeaderId JOIN dbo.AspNetUsers WITH(NOLOCK) ON AspNetUsers.VendorCode = Appointments.VendorCode where VehicleTypeId={id}").ToList();

            return result;
        }

        public async Task<IEnumerable<CustomApprovedPlugs>> GetApprovedPlugs()
        {
            var result = await _appContext.Set<CustomApprovedPlugs>()
                .FromSqlRaw("SELECT Appointments.Id,StartDate,EndDate,OrderAsnNumber,WarehouseDescription,VendorDescription,VehicleDesc,TotalPackage,TotalCHW FROM dbo.Appointments WITH(NOLOCK) JOIN dbo.VehicleTypes WITH(NOLOCK)ON VehicleTypes.Id = Appointments.VehicleTypeId JOIN  Civil_Muhasebe..trOrderAsnHeader WITH(NOLOCK) ON trOrderAsnHeader.OrderAsnHeaderID = Appointments.OrderAsnHeaderId JOIN dbo.AspNetUsers WITH(NOLOCK) ON AspNetUsers.VendorCode = Appointments.VendorCode JOIN Civil_Muhasebe..cdWarehouseDesc WITH(NOLOCK) ON cdWarehouseDesc.WarehouseCode = trOrderAsnHeader.WarehouseCode AND LangCode = N'TR'").ToListAsync();

            return result;

        }

        public async Task<IEnumerable<CustomApprovedPlugs>> GetApprovedPlugsByVendorCode(string vendorCode)
        {
            var result = await _appContext.Set<CustomApprovedPlugs>()
               .FromSqlRaw($"SELECT Appointments.Id,StartDate,EndDate,OrderAsnNumber,WarehouseDescription,VendorDescription,VehicleDesc,TotalPackage,TotalCHW FROM dbo.Appointments WITH(NOLOCK) JOIN dbo.VehicleTypes WITH(NOLOCK)ON VehicleTypes.Id = Appointments.VehicleTypeId JOIN  Civil_Muhasebe..trOrderAsnHeader WITH(NOLOCK) ON trOrderAsnHeader.OrderAsnHeaderID = Appointments.OrderAsnHeaderId JOIN dbo.AspNetUsers WITH(NOLOCK) ON AspNetUsers.VendorCode = Appointments.VendorCode JOIN Civil_Muhasebe..cdWarehouseDesc WITH(NOLOCK) ON cdWarehouseDesc.WarehouseCode = trOrderAsnHeader.WarehouseCode AND LangCode = N'TR' WHERE Appointments.VendorCode='{vendorCode}'").ToListAsync();

            return result;
        }
    }
}
