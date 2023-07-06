using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs
{
    public class VehicleInfo
    {

        public int VehicleDefId { get; set; }
        public string PlateNumber { get; set; }
        public string ImagesUrl { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public string Year { get; set; }
        public string VehicleDefinitionInfo { get { return VehicleMakeName + "-" + VehicleModelName +"-"+ Year; } }
    }
}
