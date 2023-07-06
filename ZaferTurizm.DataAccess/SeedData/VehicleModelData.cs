using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.SeedData
{
    public  class VehicleModelData
    {
        /// <summary>
        /// Mercedes Focus
        /// </summary>
        public static readonly VehicleModel VehicleModel01 = new VehicleModel() { Id = 20, VehicleMakeId = 1, Name = "Focus"};
        /// <summary>
        /// Mercedes Octavia
        /// </summary>
        public static readonly VehicleModel VehicleModel02 = new VehicleModel() { Id = 21, VehicleMakeId = 1, Name = "Octavia"};
        /// <summary>
        /// Mercedes 404
        /// </summary>
        public static readonly VehicleModel VehicleModel03 = new VehicleModel() { Id = 22, VehicleMakeId = 1, Name = "404"};
        /// <summary>
        /// Mercedes Arda
        /// </summary>
        public static readonly VehicleModel VehicleModel04 = new VehicleModel() { Id = 23, VehicleMakeId = 1, Name = "Arda"};
        /// <summary>
        /// Mercedes BBara
        /// </summary>
        public static readonly VehicleModel VehicleModel05 = new VehicleModel() { Id = 24, VehicleMakeId = 1, Name = "BBara"};
        /// <summary>
        /// Mercedes Merdo
        /// </summary>
        public static readonly VehicleModel VehicleModel06 = new VehicleModel() { Id = 25, VehicleMakeId = 1, Name = "Merdo"};
    }
}
