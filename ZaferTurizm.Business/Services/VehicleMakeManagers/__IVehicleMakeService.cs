using ZaferTurizm.DTOs.VehicleMakeAllDtos;

namespace ZaferTurizm.Business.Services.VehicleMakeManagers
{
    // CRUD, Create, Read, Update, Delete --> Standart yöntemler
    public interface __IVehicleMakeService
    {
        CommandResult Create(VehicleMakeDto model);
        CommandResult Update(VehicleMakeDto model);
        CommandResult Delete(VehicleMakeDto model);
        CommandResult Delete (int id);   

        VehicleMakeDto GetById (int id); // QueryResult döndürebilirdik
        IEnumerable<VehicleMakeDto> GetAll();
    }
}
