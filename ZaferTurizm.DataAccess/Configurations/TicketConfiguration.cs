using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.DataAccess.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(nameof(Ticket));
            builder.HasKey(t => t.Id);
            builder.Property(t => t.PaidAmount).IsRequired().HasColumnType("decimal");
            builder.Property(t => t.SeatNumber).IsRequired().HasColumnType("int");

            builder.HasOne(t => t.Passenger)
                   .WithMany()
                   .HasForeignKey(t => t.PassengerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(t=>t.BusTrip)
                   .WithMany()
                   .HasForeignKey(t=>t.BusTripId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Ticket() { Id=1, BusTripId=1, PassengerId=1, SeatNumber=1, PaidAmount=200 });
            
        }
    }
}
