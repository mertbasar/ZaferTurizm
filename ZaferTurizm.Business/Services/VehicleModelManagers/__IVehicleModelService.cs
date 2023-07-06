using ZaferTurizm.DTOs.VehicleModelAllDtos;

namespace ZaferTurizm.Business.Services.VehicleModelManagers
{
    public interface __IVehicleModelService
    {
        CommandResult Create(VehicleModelDto model);
        CommandResult Update(VehicleModelDto model);
        CommandResult Delete(VehicleModelDto model);
        CommandResult Delete(int id);

        VehicleModelDto GetById(int id); // QueryResult döndürebilirdik
        IEnumerable<VehicleModelDto> GetAll();
        IEnumerable<VehicleModelSummary> GetAllSummaries();
        IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId);


    }
}
