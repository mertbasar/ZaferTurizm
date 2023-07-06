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
    internal class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(50)");
            builder.HasData(
                CityData.Data01_Adana,
                CityData.Data02_Adıyaman,
                CityData.Data03_Afyon,
                CityData.Data04_Ağrı,
                CityData.Data05_Aksaray,
                CityData.Data06_Amasya,
                CityData.Data07_Ankara,
                CityData.Data08_Antalya,
                CityData.Data09_Ardahan,
                CityData.Data10_Artvin,
                CityData.Data11_Aydın,
                CityData.Data12_Balıkesir,
                CityData.Data13_Bartın,
                CityData.Data14_Batman,
                CityData.Data15_Bayburt,
                CityData.Data16_Bilecik,
                CityData.Data17_Bingöl,
                CityData.Data18_Bitlis,
                CityData.Data19_Bolu,
                CityData.Data20_Burdur,
                CityData.Data21_Bursa,
                CityData.Data22_Çanakkale,
                CityData.Data23_Çankırı,
                CityData.Data24_Çorum,
                CityData.Data25_Denizli,
                CityData.Data26_Diyarbakır,
                CityData.Data27_Düzce,
                CityData.Data28_Edirne,
                CityData.Data29_Elazığ,
                CityData.Data30_Erzincan,
                CityData.Data31_Erzurum,
                CityData.Data32_Eskişehir,
                CityData.Data33_Gaziantep,
                CityData.Data34_Giresun,
                CityData.Data35_Gümüşhane,
                CityData.Data36_Hakkari,
                CityData.Data37_Hatay,
                CityData.Data38_Iğdır,
                CityData.Data39_Isparta,
                CityData.Data40_İstanbul,
                CityData.Data41_İzmir,
                CityData.Data42_Kahramanmaraş,
                CityData.Data43_Karabük,
                CityData.Data44_Karaman,
                CityData.Data45_Kars,
                CityData.Data46_Kastamonu,
                CityData.Data47_Kayseri,
                CityData.Data48_Kırıkkale,
                CityData.Data49_Kırklareli,
                CityData.Data50_Kırşehir,
                CityData.Data51_Kilis,
                CityData.Data52_Kocaeli,
                CityData.Data53_Konya,
                CityData.Data54_Kütahya,
                CityData.Data55_Malatya,
                CityData.Data56_Manisa,
                CityData.Data57_Mardin,
                CityData.Data58_Mersin,
                CityData.Data59_Muğla,
                CityData.Data60_Muş,
                CityData.Data61_Nevşehir,
                CityData.Data62_Niğde,
                CityData.Data63_Ordu,
                CityData.Data64_Osmaniye,
                CityData.Data65_Rize,
                CityData.Data66_Sakarya,
                CityData.Data67_Samsun,
                CityData.Data68_Siirt,
                CityData.Data69_Sinop,
                CityData.Data70_Sivas,
                CityData.Data71_Şanlıurfa,
                CityData.Data72_Şırnak,
                CityData.Data73_Tekirdağ,
                CityData.Data74_Tokat,
                CityData.Data75_Trabzon,
                CityData.Data76_Tunceli,
                CityData.Data77_Uşak,
                CityData.Data78_Van,
                CityData.Data79_Yalova,
                CityData.Data80_Yozgat,
                CityData.Data81_Zonguldak);
    
        }
    }
}
