using AppointmentManagement.Core.DataAccess;
using AppointmentManagement.Entities.Concrete;
using AppointmentManagement.Entities.Concrete.FromSqlRaw;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.DataAccess.Abstract
{
    public interface ITrOrderAsnHeaderDal:IEntityRepository<trOrderAsnHeader>
    {
        Task<IList<OrderHeaderInfo>> GetWithCategoryNameAllAsync(string query);
    }
}
