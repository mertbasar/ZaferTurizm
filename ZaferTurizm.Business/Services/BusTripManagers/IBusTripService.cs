using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.DTOs.BusTripAllDtos;

namespace ZaferTurizm.Business.Services.BusTripManagers
{
    public interface IBusTripService: ICrudService<BusTripDto,BusTripInfo>
    {
        IEnumerable<BusTripInfo> GetTripsWithRouteId(int id);
    }
}
