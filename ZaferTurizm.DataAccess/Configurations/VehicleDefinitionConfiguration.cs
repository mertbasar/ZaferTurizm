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
    internal class VehicleDefinitionConfiguration : IEntityTypeConfiguration<VehicleDefinition>
    {
        public void Configure(EntityTypeBuilder<VehicleDefinition> builder)
        {
            builder.ToTable(nameof(VehicleDefinition));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Year).IsRequired().HasColumnName("AracınUretimYili").HasColumnType("varchar(4)");
            builder.Property(x => x.SeatCount).IsRequired().HasColumnType("int");
            builder.Property(x => x.HasToilet).IsRequired().HasColumnType("bit");
            builder.Property(x => x.HasWifi).IsRequired().HasColumnType("bit");
            builder.HasOne(x=>x.VehicleModel)
                   .WithMany()
                   .HasForeignKey(x => x.VehicleModelId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                VehicleDefinitionModelData.VehicleDefinition01,
                VehicleDefinitionModelData.VehicleDefinition02,
                VehicleDefinitionModelData.VehicleDefinition03

                );


          
        }
    }
}
