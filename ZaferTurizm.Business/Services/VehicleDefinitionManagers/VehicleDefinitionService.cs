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
using ZaferTurizm.DTOs.VehicleDefinitionAllDtos;

namespace ZaferTurizm.Business.Services.VehicleDefinitionManagers
{
    public class VehicleDefinitionService : CrudService<VehicleDefinitionDto, VehicleDefinitonSummary, VehicleDefinition>, IVehicleDefinitionService
    {
        public VehicleDefinitionService(TourDbContext context,VehicleDefinitionValidator validator) : base(context, validator)
        {
        }

        protected override Expression<Func<VehicleDefinition, VehicleDefinitionDto>> DtoMapper =>
            entity => new VehicleDefinitionDto()
            {
                Id = entity.Id,
                HasToilet = entity.HasToilet,
                HasWifi = entity.HasWifi,
                VehicleModelId = entity.VehicleModelId,
                SeatCount = entity.SeatCount,
                Year = entity.Year,
                VehicleMakeId=entity.VehicleModel.VehicleMakeId

            };
            

        protected override Expression<Func<VehicleDefinition, VehicleDefinitonSummary>> SummaryMapper => 
            entity => new VehicleDefinitonSummary()
            {
                Id = entity.Id,
                HasToilet = entity.HasToilet,
                HasWifi = entity.HasWifi,
                VehicleMakeName =entity.VehicleModel.VehicleMake.Name,
                VehicleModelName=entity.VehicleModel.Name,
                SeatCount = entity.SeatCount,
                Year = entity.Year,
                
            };

        protected override VehicleDefinition MapToEntity(VehicleDefinitionDto entity)
        {
            return new VehicleDefinition()
            {
                Id = entity.Id,
                HasToilet = entity.HasToilet,
                HasWifi = entity.HasWifi,
                VehicleModelId = entity.VehicleModelId,
                SeatCount = entity.SeatCount,
                Year = entity.Year,

            };
        }
    }
}
