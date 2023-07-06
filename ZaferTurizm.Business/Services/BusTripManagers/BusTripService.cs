using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.Business.Validators.Generics;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;
using ZaferTurizm.DTOs.BusTripAllDtos;

namespace ZaferTurizm.Business.Services.BusTripManagers
{
    public class BusTripService : CrudService<BusTripDto, BusTripInfo, BusTrip>, IBusTripService
    {
        public BusTripService(TourDbContext context,BusTripValidator validator) : base(context,validator)
        {
        }

        protected override Expression<Func<BusTrip, BusTripDto>> DtoMapper => 
            entity => new BusTripDto()
            {
                Id = entity.Id,
                RouteId = entity.RouteId,   
                VehicleId = entity.VehicleId,
                Date = entity.Date,
                Price = entity.Price,
            };

        protected override Expression<Func<BusTrip, BusTripInfo>> SummaryMapper => 
            entity => new BusTripInfo()
            {
                Id = entity.Id,
                Date = entity.Date,
                Price = entity.Price,
                DepartureName = entity.Route.DepartureCity.Name,
                ArrivalName = entity.Route.ArrivalCity.Name,
                VehicleMakeName = entity.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                VehicleModelName = entity.Vehicle.VehicleDefinition.VehicleModel.Name,
                PlateNumber = entity.Vehicle.PlateNumber,
                SeatCount = entity.Vehicle.VehicleDefinition.SeatCount,
                SoldSeatNumbers = _context.Tickets.
                Where(x=>x.BusTripId==entity.Id).
                Select(ticket => ticket.SeatNumber).ToList()
            };


                

                


        public IEnumerable<BusTripInfo> GetTripsWithRouteId(int id)
        {
            try
            {
                return _context.BusTrips
                    .Where(x => x.RouteId == id)
                    .Select(SummaryMapper).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<BusTripInfo>();

            }
        }

        protected override BusTrip MapToEntity(BusTripDto entity)
        {
            return new BusTrip()
            {
                Id = entity.Id,
                Date = entity.Date,
                Price = entity.Price,
                RouteId = entity.RouteId,
                VehicleId= entity.VehicleId,
            };
        }
    }
}
