using AppointmentManagement.Core.DataAccess.EntityFramework;
using AppointmentManagement.DataAccess.Abstract;
using AppointmentManagement.Entities.Concrete;

namespace AppointmentManagement.DataAccess.Concrete
{
    public class EfCdCurrAccCode : EfEntityRepository<cdCurrAccDesc>, ICdCurrAccDesc
    {
        //private EfCivilContext _efCivilContext { get => _context as EfCivilContext; }

        public EfCdCurrAccCode(EfCivilContext context) : base(context)
        {

        }
    }
}
