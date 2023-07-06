using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.VehicleModelAllDtos;

namespace ZaferTurizm.Business.Services.VehicleModelManagers
{


    public class __VehicleModelService : __IVehicleModelService
    {
        private readonly TourDbContext _context;

        public __VehicleModelService(TourDbContext context)
        {
            _context = context;
        }

        public CommandResult Create(VehicleModelDto model)
        {
            try
            {
                _context.Add(new VehicleModel()
                {
                    Name = model.Name,
                    VehicleMakeId = model.VehicleMakeId,
                    
                });
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch
            {

                return CommandResult.Failure();
            }
        }

        public CommandResult Delete(VehicleModelDto model)
        {
            if (model == null) return CommandResult.Failure();
            return Delete(model.Id);

            
        }

        public CommandResult Delete(int id)
        {
            var vehicleModel = new VehicleModel()
            {
                Id = id,
            };
            try
            {
                _context.Remove(vehicleModel);
                _context.SaveChanges();
                return CommandResult.Success();
            }
            catch 
            {
                return CommandResult.Failure("Kayit silme islemi basarisiz.");
            }
        }

        public IEnumerable<VehicleModelDto> GetAll()
        {//VeritabanındaVeri olmama ihtimaline karşı try catch alışkanlık haline getir...
            try
            {
                return _context.VehicleModels.Select(model => new VehicleModelDto()
                {
                    Id = model.Id,
                    Name = model.Name,
                    VehicleMakeId = model.VehicleMakeId,

                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelDto>();
            }
            
           
        }

        public IEnumerable<VehicleModelSummary> GetAllSummaries()
        {
            try
            {
                return _context.VehicleModels.Select(model => new VehicleModelSummary()
                {
                    Id = model.Id,
                    Name = model.Name,
                    VehicleMakeName = model.VehicleMake.Name,

                }).ToList();
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelSummary>();
            }
        }

        //public IEnumerable<VehicleModelDto> GetAllToMark(int id)//?
        //{
        //    throw new NotImplementedException();
        //}

        public VehicleModelDto GetById(int id)
        {
            var vehicleModel = _context.VehicleModels.FirstOrDefault(x => x.Id == id);

            try
            {
                var vehicleModelDto = new VehicleModelDto()
                {
                    Id = vehicleModel.Id,
                    Name = vehicleModel.Name,
                    VehicleMakeId = vehicleModel.VehicleMakeId,
                    
                };
                return vehicleModelDto;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId)
        {
            try
            {
                return _context.VehicleModels
                    .Where(entity => entity.VehicleMakeId == vehicleMakeId)
                    .Select(entity => new VehicleModelDto()
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        VehicleMakeId = entity.VehicleMakeId
                    }).ToList();
            }   
            catch (Exception ex)
            {
                Trace.TraceError(ex?.ToString());
                return new List<VehicleModelDto>();
                //Enumarable.Empty<VehicleModelDto>() yazmak daha doğru
            }
        }

        public CommandResult Update(VehicleModelDto model)
        {

            try
            {
                 _context.Update(new VehicleModel()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        VehicleMakeId = model.VehicleMakeId

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
