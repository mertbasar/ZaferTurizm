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
using ZaferTurizm.DTOs.VehicleModelAllDtos;

namespace ZaferTurizm.Business.Services.VehicleModelManagers
{
    public class VehicleModelService : CrudService<VehicleModelDto, VehicleModelSummary, VehicleModel>, IVehicleModelService
    {
        public VehicleModelService(TourDbContext context,VehicleModelValidator validator) : base(context, validator)
        { }
        protected override Expression<Func<VehicleModel, VehicleModelDto>> DtoMapper => 
            entity => new VehicleModelDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                VehicleMakeId = entity.VehicleMakeId,
            };

        protected override Expression<Func<VehicleModel, VehicleModelSummary>> SummaryMapper => 
            entity => new VehicleModelSummary()
            {
                Id= entity.Id,
                Name = entity.Name,
                VehicleMakeName=entity.VehicleMake.Name
            };

        public IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId)
        {
            try
            {
                return _context.VehicleModels
                       .Where(entity => entity.VehicleMakeId== vehicleMakeId)
                       .Select(DtoMapper)
                       .ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<VehicleModelDto>();
            }
        }
        protected override VehicleModel MapToEntity(VehicleModelDto entity)
        {
            return new VehicleModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                VehicleMakeId = entity.VehicleMakeId,
            };
        }
                

    }
}
