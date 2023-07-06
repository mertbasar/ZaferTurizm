using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.DTOs.RouteAllDtos
{
    public class RouteSummary
    {
        public int Id { get; set; }
        public string DepartureName { get; set; }
        public string ArrivalName { get; set; }
        //Computed Property
        public string RouteName { get { return DepartureName + "->" + ArrivalName; } }


    }
}
