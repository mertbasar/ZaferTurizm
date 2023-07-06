using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    public class VehicleDefinitionModelData
    {
        public  static readonly VehicleDefinition VehicleDefinition01 = new VehicleDefinition()
            {
                Id = 1,
                VehicleModelId = VehicleModelData.VehicleModel01.Id,
                HasToilet = true,
                HasWifi = false,
                SeatCount = 25,
                Year = "2020",
            };
        public  static readonly VehicleDefinition VehicleDefinition02 = new VehicleDefinition()
            {
                Id = 2,
                VehicleModelId = VehicleModelData.VehicleModel01.Id,
                HasToilet = true,
                HasWifi = true,
                SeatCount = 48,
                Year = "2022",
            };
        public  static readonly VehicleDefinition VehicleDefinition03 = new VehicleDefinition()
            {
                Id = 3,
                VehicleModelId = VehicleModelData.VehicleModel04.Id,
                HasToilet = true,
                HasWifi = true,
                SeatCount = 52,
                Year = "2023",
            };



    }
}
