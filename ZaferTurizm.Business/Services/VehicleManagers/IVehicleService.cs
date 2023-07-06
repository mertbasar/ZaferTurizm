using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.DTOs.VehicleAllDtos;

namespace ZaferTurizm.Business.Services.VehicleManagers
{
    public interface IVehicleService :ICrudService<VehicleDto,VehicleSummary>
    { }
}
