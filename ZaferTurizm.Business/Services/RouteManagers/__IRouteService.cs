using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DTOs.RouteAllDtos;

namespace ZaferTurizm.Business.Services.RouteManagers
{
    public interface __IRouteService
    {
        CommandResult Create(RouteDto model);
        CommandResult Update(RouteDto model);
        CommandResult Delete(RouteDto model);
        CommandResult Delete(int id);

        //VehicleDefinitionUpdateType GetById(int id);
        // QueryResult döndürebilirdik

        RouteDto? GetById(int id);

        IEnumerable<RouteDto> GetAll();

        IEnumerable<RouteSummary> GetSumAll();
    }
}
