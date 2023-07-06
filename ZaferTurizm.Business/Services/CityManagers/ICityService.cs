using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.CityAllDtos;

namespace ZaferTurizm.Business.Services.CityManagers
{
    public interface ICityService
    {
        CityDto GetCity(int id);
        IEnumerable<CityDto> GetAllCities();
    }
}
