using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DTOs.VehicleDefinitionAllDtos;

namespace ZaferTurizm.Business.Services.VehicleDefinitionManagers
{
    public interface __IVehicleDefinitonService
    {
        CommandResult Create(VehicleDefinitionDto model);
        CommandResult Update(VehicleDefinitionDto model);
        CommandResult Delete(VehicleDefinitionDto model);
        CommandResult Delete(int id);

        //VehicleDefinitionUpdateType GetById(int id);
        // QueryResult döndürebilirdik
        
        VehicleDefinitionDto? GetById(int id);

        IEnumerable<VehicleDefinitionDto> GetAll();
        IEnumerable<VehicleDefinitonSummary> GetAllSummaries();
    }
}
