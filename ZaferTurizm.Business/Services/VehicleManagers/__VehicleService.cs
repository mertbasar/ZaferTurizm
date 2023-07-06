using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs;
using ZaferTurizm.DTOs.VehicleAllDtos;

namespace ZaferTurizm.Business.Services.VehicleManagers
{
    public class __VehicleService : __IVehicleService
    {
        private readonly TourDbContext _context;
        public __VehicleService(TourDbContext context)
        {
            _context = context;
        }
        public CommandResult Create(VehicleDto model)
        {
            try
            {
                
                    _context.Add(new Vehicle()
                {
                    Id = model.Id,
                    ImagesUrl = model.ImagesUrl,
                    PlateNumber = model.PlateNumber,
                    VehicleDefinitionId = model.VehicleDefinitionId
                });
                _context.SaveChanges();
                return CommandResult.Success();

            }
            catch (Exception)
            {

                return CommandResult.Failure();

            }
        }

        public CommandResult Delete(VehicleDto model)
        {
            if (model == null) return CommandResult.Failure();
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var vehicle = new Vehicle()
            {
                Id = id,
            };
            try
            {
                _context.Remove(vehicle);
                _context.SaveChanges();
                return CommandResult.Success("Araç silme başarılı Selm oşşşş");
            }
            catch
            {
                return CommandResult.Failure("Kayit silme islemi basarisiz.");
            }
        }

        public IEnumerable<VehicleDto> GetAll()
        {
            try
            {
                return _context.Vehicles.Select(model => new VehicleDto()
                {
                    Id = model.Id,
                    ImagesUrl=model.ImagesUrl,
                    PlateNumber=model.PlateNumber,
                    VehicleDefinitionId=model.VehicleDefinitionId

                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleDto>();
            }
        }

        public IEnumerable<VehicleInfo> GetAllInfo()
        {
            
            try
            {
                //return _context.Vehicles.Select(model => new VehicleInfo()
                //{
                //    ImagesUrl = model.ImagesUrl,
                //    PlateNumber=model.PlateNumber,

                //})
                return (from veh in _context.Vehicles
                        join vd in _context.VehicleDefinitions on veh.VehicleDefinitionId equals vd.Id
                        select new VehicleInfo()
                        {
                            PlateNumber = veh.PlateNumber,
                            VehicleMakeName = vd.VehicleModel.VehicleMake.Name,
                            VehicleModelName = vd.VehicleModel.Name,
                            Year = vd.Year,
                            ImagesUrl = veh.ImagesUrl,
                            VehicleDefId = veh.VehicleDefinitionId
                        }).ToList();


            }
            catch (Exception ex )
            {
                Trace.TraceError (ex.ToString());
                return Enumerable.Empty<VehicleInfo>();
                
            }
        }

        public IEnumerable<VehicleSummary> GetAllSummaries()
        {
            try
            {
                return _context.Vehicles.Select(model => new VehicleSummary()
                {
                   Id=model.Id,
                   PlateNumber=model.PlateNumber,
                   VehicleMakeName=model.VehicleDefinition.VehicleModel.VehicleMake.Name,
                   VehicleModelName=model.VehicleDefinition.VehicleModel.Name,
                   VehicleSeatCount=model.VehicleDefinition.SeatCount,
                   HasToilet=model.VehicleDefinition.HasToilet,
                   HasWifi=model.VehicleDefinition.HasWifi,
                   VehicleYear=model.VehicleDefinition.Year,
                   ImagesUrl=model.ImagesUrl

                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleSummary>();
            }
        }

        public VehicleDto GetById(int id)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == id);

            try
            {
                var vehicleDto = new VehicleDto()
                {
                    Id = vehicle.Id,
                    PlateNumber=vehicle.PlateNumber,
                    ImagesUrl=vehicle.ImagesUrl,
                    VehicleDefinitionId=vehicle.VehicleDefinitionId
                };
                return vehicleDto;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<VehicleDto> GetByMakeId(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public CommandResult Update(VehicleDto model)
        {
            try
            {
                _context.Update(new Vehicle()
                {
                    Id = model.Id,
                   ImagesUrl=model.ImagesUrl,
                   PlateNumber=model.PlateNumber,
                   VehicleDefinitionId=model.VehicleDefinitionId

                });
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch
            {

                return CommandResult.Failure();
            }
        }
    }
}
