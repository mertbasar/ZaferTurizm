using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.BusTripAllDtos;

namespace ZaferTurizm.Business.Services.BusTripManagers
{
    public class __BusTripService : __IBusTripService
    {
        private readonly TourDbContext _context;

        public __BusTripService(TourDbContext context)
        {
            _context = context;
        }

        public CommandResult Create(BusTripDto model)
        {
            if (model == null)
            { return CommandResult.Failure("Oluşturulmaya çalışan model bulunmuyor"); }

            try
            {
                var bt = new BusTrip()
                { 
                    Price = model.Price,
                    Date= model.Date,
                    RouteId = model.RouteId,
                    VehicleId = model.VehicleId,

                    
                };
                _context.BusTrips.Add(bt);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("BusTrip ekleme işlemi başarısız.");
            }
        }

        public CommandResult Delete(BusTripDto model)
        {
            if (model == null) return CommandResult.Failure("Silinecek veri gelmedi bana");
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var bt = new BusTrip()
            {
                Id = id,
            };
            try
            {
                _context.BusTrips.Remove(bt);
                _context.SaveChanges();
                return CommandResult.Success("BusTrip Silme işlemi başarılı..");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("İşlem Başarısız canım");

            }
        }

       
        public IEnumerable<BusTripDto> GetAll()
        {
            try
            {
                return _context.BusTrips.Select(model => new BusTripDto()
                {
                    Id = model.Id,
                    Price = model.Price,
                    Date = model.Date,
                    RouteId = model.RouteId,
                    VehicleId = model.VehicleId

                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<BusTripDto>();
            }
        }

        public BusTripDto? GetById(int id)
        {
            try
            {
                return _context.BusTrips.Select(model => new BusTripDto()
                {
                    Id = model.Id,
                    Price = model.Price,
                    Date = model.Date,
                    RouteId = model.RouteId,
                    VehicleId = model.VehicleId

                }).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public IEnumerable<BusTripInfo> GetSumAll()
        {
            return _context.BusTrips.Select(model => new BusTripInfo()
            {
                Id = model.Id,
                Date = model.Date,
                Price= model.Price,
                DepartureName = model.Route.DepartureCity.Name,
                ArrivalName=model.Route.ArrivalCity.Name,
                VehicleMakeName=model.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                VehicleModelName=model.Vehicle.VehicleDefinition.VehicleModel.Name,
                PlateNumber = model.Vehicle.PlateNumber,
                
                

            }).ToList();
        }

        public IEnumerable<BusTripInfo> GetTripsWithRouteId(int id)
        {
            try
            {
                return _context.BusTrips
                    .Where(x => x.RouteId == id)
                    .Select(x => new BusTripInfo()
                    {
                        Id = x.Id,
                        Date = x.Date,
                        Price = x.Price,
                        VehicleMakeName = x.Vehicle.VehicleDefinition.VehicleModel.VehicleMake.Name,
                        VehicleModelName = x.Vehicle.VehicleDefinition.VehicleModel.Name,
                        DepartureName = x.Route.DepartureCity.Name,
                        ArrivalName = x.Route.ArrivalCity.Name,
                        PlateNumber = x.Vehicle.PlateNumber
                    }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<BusTripInfo>();
                
            }
        }

        public CommandResult Update(BusTripDto model)
        {
            throw new NotImplementedException();
        }

       
    }
}
