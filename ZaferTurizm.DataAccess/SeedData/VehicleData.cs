using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    public class VehicleData
    {
        /// <summary>
        /// Vehicle1
        /// </summary>
        public static readonly Vehicle Vehicle01 = new Vehicle() { Id = 1, ImagesUrl = "", PlateNumber = "34 ABC 34", VehicleDefinitionId = VehicleDefinitionModelData.VehicleDefinition01.Id };
        /// <summary>
        /// Vehicle2
        /// </summary>
        public static readonly Vehicle Vehicle02 = new Vehicle() { Id = 2, ImagesUrl = "", PlateNumber = "34 MRT 34", VehicleDefinitionId = VehicleDefinitionModelData.VehicleDefinition02.Id };
        /// <summary>
        /// Vehicle3
        /// </summary>
        public static readonly Vehicle Vehicle03 = new Vehicle() { Id = 3, ImagesUrl = "", PlateNumber = "34 BSR 34", VehicleDefinitionId = VehicleDefinitionModelData.VehicleDefinition03.Id };
        /// <summary>
        /// Vehicle4
        /// </summary>
        public static readonly Vehicle Vehicle04 = new Vehicle() { Id = 4, ImagesUrl = "", PlateNumber = "31 MST 31", VehicleDefinitionId = VehicleDefinitionModelData.VehicleDefinition03.Id };

    }
}
