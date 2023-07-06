using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.Business.Validators.Generics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.RouteAllDtos;

namespace ZaferTurizm.Business.Services.RouteManagers
{
    public class RouteService : CrudService<RouteDto, RouteSummary, Route>, IRouteService
    {
        public RouteService(TourDbContext context,RouteValidator routeValidator) : base(context, routeValidator)
        {
        }

        protected override Expression<Func<Route, RouteDto>> DtoMapper => 
            entity => new RouteDto
            {
                Id = entity.Id,
                ArrivalId=entity.ArrivalCityId,
                DepartuteId=entity.DepartureCityId
            };

        protected override Expression<Func<Route, RouteSummary>> SummaryMapper => 
            entity => new RouteSummary()
            {
                Id=entity.Id,
                ArrivalName=entity.ArrivalCity.Name,
                DepartureName=entity.DepartureCity.Name
            };

        protected override Route MapToEntity(RouteDto entity)
        {
            return new Route()
            {
                Id = entity.Id,
                ArrivalCityId = entity.ArrivalId,
                DepartureCityId = entity.DepartuteId
            };
        }
    }
}
