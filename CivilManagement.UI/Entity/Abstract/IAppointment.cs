using AppointmentManagement.Core.DataAccess;
using AppointmentManagement.UI.Entity.CustomEntity;
using AppointmentManagement.UI.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagement.UI.Entity.Abstract
{
    public interface IAppointment:IEntityRepository<Appointment>
    {
        IList<CustomAppointment> GetRegisteredAppointment();
        IList<CustomAppointment> GetRegisteredAppointmentByVehicleTypeId(int id);
        Task<IEnumerable<CustomApprovedPlugs>> GetApprovedPlugs();
        Task<IEnumerable<CustomApprovedPlugs>> GetApprovedPlugsByVendorCode(string vendorCode);
    }
}
