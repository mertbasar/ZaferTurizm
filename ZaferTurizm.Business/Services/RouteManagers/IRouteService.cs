using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.DTOs.RouteAllDtos;

namespace ZaferTurizm.Business.Services.RouteManagers
{
    public interface IRouteService : ICrudService<RouteDto,RouteSummary>
    {
    }
}
