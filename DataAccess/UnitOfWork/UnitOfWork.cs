using AppointmentManagement.Core.DataAccess.EntityFramework;
using AppointmentManagement.DataAccess.Abstract;
using AppointmentManagement.DataAccess.Abstract.Procedure;
using AppointmentManagement.DataAccess.Concrete;
using AppointmentManagement.DataAccess.Concrete.Procedure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentManagement.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EfCivilContext _civilContext;
        private readonly EfAppointmentContext _appointmentContext;
        private EfTrOrderAsnHeaderDal _trOrderAsnHeader;
        private EfCdCurrAccCode _cdCurrAccCode;
        private IDataProcedure _dataProcedure;
        private IVehicleTypesDal _vehicleTypes;
        private IPostedTypeDal _postedType;
        private IOrderWarehouseDal _orderWarehouse;


        public UnitOfWork(EfCivilContext civilContext, EfAppointmentContext appointmentContext)
        {
            _civilContext = civilContext;
            _appointmentContext = appointmentContext;
        }

        public IDataProcedure DataProcedure => _dataProcedure = _dataProcedure ?? new EfDataProcedure(_civilContext);

        public IVehicleTypesDal VehicleTypes => _vehicleTypes = _vehicleTypes ?? new EfVehicleTypesDal(_civilContext);

        public IPostedTypeDal PostedType => _postedType = _postedType ?? new EfPostedTypeDal(_civilContext);

        public IOrderWarehouseDal OrderWarehouse => _orderWarehouse = _orderWarehouse ?? new EfOrderWarehouseDal(_civilContext);

        public ITrOrderAsnHeaderDal trOrderAsnHeader => _trOrderAsnHeader = _trOrderAsnHeader ?? new EfTrOrderAsnHeaderDal(_civilContext);

        public ICdCurrAccDesc cdCurrAccDesc => _cdCurrAccCode = _cdCurrAccCode ?? new EfCdCurrAccCode(_civilContext);

        public void Commit()
        {
            _civilContext.SaveChanges();
        }

        public Task CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public Task RollBackAsync()
        {
            throw new NotImplementedException();
        }

        public void V3Commit()
        {
            _civilContext.SaveChanges();
        }

        public async Task V3CommitAsync()
        {
            await _civilContext.SaveChangesAsync();
        }

        public void V3RollBack()
        {
            _civilContext.Dispose();
        }

        public async Task V3RollBackAsync()
        {
            await _civilContext.DisposeAsync();
        }
    }
}
