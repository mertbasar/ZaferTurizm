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
using ZaferTurizm.DTOs.VehicleAllDtos;

namespace ZaferTurizm.Business.Services.VehicleManagers
{
    public class VehicleService : CrudService<VehicleDto, VehicleSummary, Vehicle>, IVehicleService
    {
        public VehicleService(TourDbContext context,VehicleValidator vehicleValidator) : base(context, vehicleValidator)
        { }

        protected override Expression<Func<Vehicle, VehicleDto>> DtoMapper => 
            entity => new VehicleDto()
            {
                Id = entity.Id,
                PlateNumber = entity.PlateNumber,
                VehicleDefinitionId = entity.VehicleDefinitionId,
                ImagesUrl = entity.ImagesUrl
                
            };

        protected override Expression<Func<Vehicle, VehicleSummary>> SummaryMapper => 
            entity => new VehicleSummary()
            {
                Id= entity.Id,
                PlateNumber= entity.PlateNumber,
                ImagesUrl= entity.ImagesUrl,
                VehicleMakeName=entity.VehicleDefinition.VehicleModel.VehicleMake.Name,
                VehicleModelName=entity.VehicleDefinition.VehicleModel.Name,
                VehicleSeatCount=entity.VehicleDefinition.SeatCount,
                VehicleYear=entity.VehicleDefinition.Year,
                HasToilet=entity.VehicleDefinition.HasToilet,
                HasWifi=entity.VehicleDefinition.HasWifi,
                VehicleDefId=entity.VehicleDefinitionId
                
            };

        protected override Vehicle MapToEntity(VehicleDto entity)
        {
            return new Vehicle()
            {
                Id = entity.Id,
                PlateNumber = entity.PlateNumber,
                ImagesUrl = entity.ImagesUrl,
                VehicleDefinitionId = entity.VehicleDefinitionId,

            };
        }

    }
}
