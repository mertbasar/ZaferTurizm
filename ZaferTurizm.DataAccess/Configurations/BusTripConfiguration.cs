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
    public class BusTripConfiguration : IEntityTypeConfiguration<BusTrip>
    {
        public void Configure(EntityTypeBuilder<BusTrip> builder)
        {
            builder.ToTable(nameof(BusTrip));
            builder.HasKey(bt => bt.Id);
            builder.Property(bt => bt.Price).IsRequired().HasColumnType("money");
            builder.Property(bt => bt.Date).IsRequired().HasColumnType("datetime2(0)");

            builder.HasOne(bt => bt.Route)
                   .WithMany()
                   .HasForeignKey(bt => bt.RouteId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bt => bt.Vehicle)
                   .WithMany()
                   .HasForeignKey(bt=>bt.VehicleId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData( new BusTrip() { Id=1 , RouteId=RouteData.RotaIstanbul.Id, VehicleId=VehicleData.Vehicle01.Id,Date=DateTime.Parse("2023-06-30"), Price=200});

        }
    }
}
