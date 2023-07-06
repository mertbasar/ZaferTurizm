using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.Configurations;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    internal class RouteData
    {
        public static readonly Route RotaIzmir = new Route()
        {
            Id = 1,
            DepartureCityId = CityData.Data41_İzmir.Id,
            ArrivalCityId = CityData.Data40_İstanbul.Id,
        };
        public static readonly Route RotaIstanbul = new Route()
        {
            Id = 2,
            DepartureCityId = CityData.Data40_İstanbul.Id,
            ArrivalCityId = CityData.Data37_Hatay.Id,
        };
        public static readonly Route RotaAntalya= new Route()
        {
            Id = 3,
            DepartureCityId = CityData.Data08_Antalya.Id,
            ArrivalCityId = CityData.Data46_Kastamonu.Id,
        };
        public static readonly Route RotaAnkara = new Route()
        {
            Id = 4,
            DepartureCityId = CityData.Data07_Ankara.Id,
            ArrivalCityId = CityData.Data01_Adana.Id,
        };
    }
}
