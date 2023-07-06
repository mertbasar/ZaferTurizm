using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.RouteAllDtos;

namespace ZaferTurizm.Business.Services.RouteManagers
{
    public class __RouteService : __IRouteService
    {
        private readonly TourDbContext _context;

        public __RouteService(TourDbContext context)
        {
            _context = context;
        }

        public CommandResult Create(RouteDto model)
        {
            if (model == null)
            { return CommandResult.Failure("Oluşturulmaya çalışan model bulunmuyor"); }

            try
            {
                var pas = new Route()
                {
                    DepartureCityId=model.DepartuteId,
                    ArrivalCityId=model.ArrivalId
                };
                _context.Routes.Add(pas);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Route ekleme işlemi başarısız.");
            }
        }

        public CommandResult Delete(RouteDto model)
        {
            if (model == null) return CommandResult.Failure("Silinecek veri gelmedi bana");
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var vehDef = new Route()
            {
                Id = id,
            };
            try
            {
                _context.Routes.Remove(vehDef);
                _context.SaveChanges();
                return CommandResult.Success("Route Silme işlemi başarılı..");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("İşlem Başarısız..");

            }
        }

        public IEnumerable<RouteDto> GetAll()
        {
            try
            {
                return _context.Routes.Select(model => new RouteDto()
                {
                    DepartuteId=model.DepartureCityId,
                    ArrivalId=model.ArrivalCityId

                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<RouteDto>();
            }
        }

        public RouteDto? GetById(int id)
        {
            try
            {
                return _context.Routes.Select(model => new RouteDto()
                {
                    DepartuteId=model.DepartureCityId,
                    ArrivalId=model.ArrivalCityId

                }).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

        public IEnumerable<RouteSummary> GetSumAll()
        {
            return _context.Routes.Select(model => new RouteSummary()
            {
                Id = model.Id,
                ArrivalName = model.ArrivalCity.Name,
                DepartureName = model.DepartureCity.Name

            }).ToList();    
        }

        public CommandResult Update(RouteDto model)
        {
            try
            {
                _context.Update(new RouteDto()
                {
                    DepartuteId=model.DepartuteId,
                    ArrivalId=model.ArrivalId
                });
                _context.SaveChanges();
                return CommandResult.Success("Route güncelleme işlemi başarılı");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("İşlem başarısız..");
            }
        }
    }
}
