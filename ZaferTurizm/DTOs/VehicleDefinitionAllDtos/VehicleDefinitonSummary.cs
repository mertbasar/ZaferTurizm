using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.VehicleDefinitionAllDtos
{
    public class VehicleDefinitonSummary
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public bool HasToilet { get; set; }

        public int SeatCount { get; set; }
        public bool HasWifi { get; set; }

        public string VehicleModelName { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleAllInfo
        {
            get
            {
                return VehicleMakeName + " - " + VehicleModelName + " - " + Year;
            }
        }
        public string HasToiletString => HasToilet ? "Var" : "Yok"; //Sadece arrow function varsa readonlydir...
        public string HasWifiString
        {
            get
            {
                return HasToilet ? "Var" : "Yok";
            }
        }
    }
}
