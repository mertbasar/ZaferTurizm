using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.VehicleDefinitionAllDtos;

namespace ZaferTurizm.Business.Services.VehicleDefinitionManagers
{
    public interface IVehicleDefinitionService :ICrudService<VehicleDefinitionDto,VehicleDefinitonSummary>
    { }
}
