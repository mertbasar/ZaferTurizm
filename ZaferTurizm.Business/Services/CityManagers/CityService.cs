using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.DTOs.CityAllDtos;

namespace ZaferTurizm.Business.Services.CityManagers
{
    public class CityService : ICityService
    {
        private readonly TourDbContext _context;
       

        public CityService(TourDbContext context)
        {
            _context = context;
        }

       

        IEnumerable<CityDto> ICityService.GetAllCities()
        {
            try
            {
                return _context.Cities.Select(c => new CityDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<CityDto>();
                
            }
        }

        CityDto ICityService.GetCity(int id)
        {
            try
            {
                var findedCity = _context.Cities.Find(id);
                var cityDto = new CityDto()
                {
                    Id = findedCity.Id,
                    Name = findedCity.Name
                };
                return cityDto;
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return null;

            }
        }
    }
}
