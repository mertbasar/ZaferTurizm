using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.DTOs.VehicleMakeAllDtos;

namespace ZaferTurizm.Business.Services.VehicleMakeManagers
{
    public interface IVehicleMakeService : ICrudService<VehicleMakeDto,VehicleMakeSummary>
    { }
}
