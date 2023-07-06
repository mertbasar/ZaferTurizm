using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DTOs;
using ZaferTurizm.DTOs.VehicleAllDtos;

namespace ZaferTurizm.Business.Services.VehicleManagers
{
    public interface __IVehicleService
    {
        CommandResult Create(VehicleDto model);
        CommandResult Update(VehicleDto model);
        CommandResult Delete(VehicleDto model);
        CommandResult Delete(int id);

        VehicleDto GetById(int id); // QueryResult döndürebilirdik
        IEnumerable<VehicleDto> GetAll();
        IEnumerable<VehicleSummary> GetAllSummaries();
        IEnumerable<VehicleDto> GetByMakeId(int vehicleId);

        IEnumerable<VehicleInfo> GetAllInfo();// Vehicle İçin ınfo olanları Get All Summaries ile değiş
    }
}
