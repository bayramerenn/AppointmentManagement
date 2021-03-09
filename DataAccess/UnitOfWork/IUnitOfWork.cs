using AppointmentManagement.DataAccess.Abstract;
using AppointmentManagement.DataAccess.Abstract.Procedure;
using AppointmentManagement.DataAccess.Concrete;
using System.Threading.Tasks;

namespace AppointmentManagement.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IDataProcedure DataProcedure { get; }
        IVehicleTypesDal VehicleTypes { get; }
        IPostedTypeDal PostedType { get; }
        IOrderWarehouseDal OrderWarehouse { get; }
        ITrOrderAsnHeaderDal trOrderAsnHeader { get; }
        ICdCurrAccDesc cdCurrAccDesc { get; }
        Task V3CommitAsync();
        void V3Commit();
        void V3RollBack();

        Task V3RollBackAsync();

        Task CommitAsync();

        void Commit();

        void RollBack();

        Task RollBackAsync();
    }
}