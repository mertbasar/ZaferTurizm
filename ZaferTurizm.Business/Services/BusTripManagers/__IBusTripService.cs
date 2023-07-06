using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DTOs.BusTripAllDtos;

namespace ZaferTurizm.Business.Services.BusTripManagers
{
    public interface __IBusTripService
    {
        CommandResult Create(BusTripDto model);
        CommandResult Update(BusTripDto model);
        CommandResult Delete(BusTripDto model);
        CommandResult Delete(int id);

        //VehicleDefinitionUpdateType GetById(int id);
        // QueryResult döndürebilirdik

        BusTripDto? GetById(int id);

        IEnumerable<BusTripDto> GetAll();

        IEnumerable<BusTripInfo> GetSumAll();

        IEnumerable<BusTripInfo> GetTripsWithRouteId (int id);
    }
}
