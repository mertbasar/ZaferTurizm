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
using ZaferTurizm.DTOs.VehicleMakeAllDtos;

namespace ZaferTurizm.Business.Services.VehicleMakeManagers
{
    public class VehicleMakeService : CrudService<VehicleMakeDto, VehicleMakeSummary, VehicleMake>, IVehicleMakeService
    {
        public VehicleMakeService(TourDbContext dbContext,VehicleMakeValidator vehicleMakeValidator) : base(dbContext, vehicleMakeValidator) { }
        protected override Expression<Func<VehicleMake, VehicleMakeDto>> DtoMapper => 
            entity => new VehicleMakeDto()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

        protected override Expression<Func<VehicleMake, VehicleMakeSummary>> SummaryMapper => 
            entity => new VehicleMakeSummary()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

        protected override VehicleMake MapToEntity(VehicleMakeDto entity)
        {
            return new VehicleMake()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
        
    }
}
