using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.VehicleDefinitionAllDtos;

namespace ZaferTurizm.Business.Services.VehicleDefinitionManagers
{
    public class __VehicleDefinitionService : __IVehicleDefinitonService
    {
        private readonly TourDbContext _tourDbContext;

        public __VehicleDefinitionService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }



        public CommandResult Create(VehicleDefinitionDto model)
        {
            if (model == null)
            { return CommandResult.Failure("Oluşturulmaya çalışan model bulunmuyor"); }

            try
            {
                var vdto = new VehicleDefinition()
                {
                    Year = model.Year,
                    SeatCount = model.SeatCount,
                    HasToilet = model.HasToilet,
                    HasWifi = model.HasWifi,
                    VehicleModelId = model.VehicleModelId,

                };
                _tourDbContext.VehicleDefinitions.Add(vdto);
                _tourDbContext.SaveChanges();
                return CommandResult.Success();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("Definition ekleme işlemi başarısız.");
            }

        }

        public CommandResult Delete(VehicleDefinitionDto model)
        {
            if (model==null)  return CommandResult.Failure("Silinecek veri gelmedi bana");
            return Delete(model.Id);
        }

        public CommandResult Delete(int id)
        {
            var vehDef = new VehicleDefinition()
            {
                Id = id,
            };
            try
            {
                _tourDbContext.VehicleDefinitions.Remove(vehDef);
                _tourDbContext.SaveChanges();
                return CommandResult.Success("Vehicle Definition Silme işlemi başarılı..");
            }
            catch (Exception ex)
            {
                Trace.TraceError (ex.ToString());
                return CommandResult.Failure("İşlem Başarısız canım");
                
            }
        }

        public IEnumerable<VehicleDefinitionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleDefinitonSummary> GetAllSummaries()
        {
            try
            {
                return _tourDbContext.VehicleDefinitions.Select(def => new VehicleDefinitonSummary()
                {
                    Id = def.Id,
                    HasToilet = def.HasToilet,
                    HasWifi = def.HasWifi,
                    SeatCount = def.SeatCount,
                    Year = def.Year,
                    VehicleMakeName = def.VehicleModel.VehicleMake.Name,
                    VehicleModelName = def.VehicleModel.Name


                }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleDefinitonSummary>();
            }
        }

        public VehicleDefinitionDto? GetById(int id)
        {
            try
            {
                return _tourDbContext.VehicleDefinitions.Select(model => new VehicleDefinitionDto()
                {
                    Id = model.Id,
                    VehicleModelId=model.VehicleModelId,
                    Year=model.Year,
                    HasToilet=model.HasToilet,
                    SeatCount=model.SeatCount,
                    HasWifi=model.HasWifi,
                    VehicleMakeId = model.VehicleModel.VehicleMakeId

                }).SingleOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;
            }
        }

      

        public CommandResult Update(VehicleDefinitionDto model)
        {
            try
            {
                _tourDbContext.Update(new VehicleDefinitionDto()
                {
                    Id = model.Id,
                    VehicleModelId = model.VehicleModelId,
                    Year = model.Year,
                    HasToilet = model.HasToilet,
                    HasWifi = model.HasWifi,
                    SeatCount = model.SeatCount
                });
                _tourDbContext.SaveChanges();
                return CommandResult.Success("Vehicle Definintion güncelleme işlemi başarılı");
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return CommandResult.Failure("İşlem başarısız balım");
            }
        }
    }

                





}
