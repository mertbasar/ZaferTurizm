using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DTOs.PassengerAllDtos;

namespace ZaferTurizm.Business.Services.PassengerManagers
{
    public interface __IPassengerService
    {
        CommandResult Create(PassengerDto model);
        CommandResult Update(PassengerDto model);
        CommandResult Delete(PassengerDto model);
        CommandResult Delete(int id);

        //VehicleDefinitionUpdateType GetById(int id);
        // QueryResult döndürebilirdik

        PassengerDto? GetById(int id);

        IEnumerable<PassengerDto> GetAll();
        
    }
}
