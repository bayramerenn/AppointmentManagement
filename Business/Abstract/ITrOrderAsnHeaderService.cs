using AppointmentManagement.Entities.Concrete;
using AppointmentManagement.Entities.Concrete.FromSqlRaw;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.Business.Abstract
{
    public interface ITrOrderAsnHeaderService
    {
        Task<IEnumerable<trOrderAsnHeader>> GetOrderAsnHeadersAsync(Expression<Func<trOrderAsnHeader, bool>> predicate=null);
        Task<IList<OrderHeaderInfo>> GetWithCategoryNameAllAsync();

        Task<trOrderAsnHeader> GetTrOrderAsnHeaderAsync(Guid orderAsnHeaderId);

        void Update(trOrderAsnHeader entity);
        
    }
}
