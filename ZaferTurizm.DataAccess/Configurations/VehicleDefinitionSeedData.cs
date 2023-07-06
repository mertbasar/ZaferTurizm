using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess.SeedData;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{

    public class VehicleDefinitionSeedData : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasData(
                VehicleModelData.VehicleModel01,
                VehicleModelData.VehicleModel02,
                VehicleModelData.VehicleModel03,
                VehicleModelData.VehicleModel04,
                VehicleModelData.VehicleModel05,
                VehicleModelData.VehicleModel06

                );
        }
    }
}
