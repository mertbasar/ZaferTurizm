using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Vehicle : IEntity
    {
        public int Id { get; set; }
        public string PlateNumber { get; set; }
        public string ImagesUrl { get; set; }
        public int VehicleDefinitionId { get; set; }
        public VehicleDefinition VehicleDefinition { get; set; }
    }
}
