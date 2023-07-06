using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Business.Services.GenericCrudManagers;
using ZaferTurizm.DTOs;
using ZaferTurizm.DTOs.PassengerAllDtos;

namespace ZaferTurizm.Business.Services.PassengerManagers
{
    public interface IPassengerService : ICrudService<PassengerDto,PassengerSummary>
    {
    }
}
