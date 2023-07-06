using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.DTOs.VehicleModelAllDtos;

namespace ZaferTurizm.Business.Services.VehicleModelManagers
{
    public interface IVehicleModelService : ICrudService<VehicleModelDto,VehicleModelSummary>
    {
        IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId);
    }
}
