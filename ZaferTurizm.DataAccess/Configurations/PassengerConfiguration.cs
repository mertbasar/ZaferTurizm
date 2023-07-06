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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.ToTable(nameof(Passenger));
            builder.HasKey(pas => pas.Id);
            builder.Property(pas=>pas.FirstName).IsRequired().HasColumnType("varchar(20)");
            builder.Property(pas=>pas.LastName).IsRequired().HasColumnType("varchar(20)");
            builder.Property(pas=>pas.IdentityNumber).IsRequired(false).HasColumnType("varchar(20)");
            builder.Property(pas => pas.Gender).IsRequired().HasColumnType("int").HasColumnName("Cinsiyet");
            builder.Property(pas => pas.Age).IsRequired().HasColumnType("int");
            builder.Property(pas => pas.PhoneNumber).IsRequired().HasColumnType("varchar(50)");

            builder.HasData(new Passenger() { Id = 1, FirstName = "Arda", LastName = "Korkmaz", Gender = Gender.Male, Age = 31, PhoneNumber = "05552313234", IdentityNumber="" });
            

        }
    }
}
