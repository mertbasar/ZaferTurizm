using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.VehicleAllDtos
{
    public class VehicleSummary
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string ImagesUrl { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public int VehicleSeatCount { get; set; }
        public string VehicleWifiStatus => HasWifi ? "Var" : "Yok";
        public string VehicleToiletStatus => HasToilet ? "Var" : "Yok";
        public string VehicleYear { get; set; }
        public bool HasToilet { get; set; }
        public bool HasWifi { get; set; }
        public string VehicleDefinitionInfo { get { return VehicleMakeName + "-" + VehicleModelName + "-" + PlateNumber; } }
        public int VehicleDefId { get; set; }

    }
}
