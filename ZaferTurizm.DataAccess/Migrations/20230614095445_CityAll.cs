using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class CityAll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Adıyaman" },
                    { 3, "Afyon" },
                    { 4, "Ağrı" },
                    { 5, "Aksaray" },
                    { 6, "Amasya" },
                    { 9, "Ardahan" },
                    { 10, "Artvin" },
                    { 11, "Aydın" },
                    { 12, "Balıkesir" },
                    { 13, "Bartın" },
                    { 14, "Batman" },
                    { 15, "Bayburt" },
                    { 16, "Bilecik" },
                    { 17, "Bingöl" },
                    { 18, "Bitlis" },
                    { 19, "Bolu" },
                    { 20, "Burdur" },
                    { 21, "Bursa" },
                    { 22, "Çanakkale" },
                    { 23, "Çankırı" },
                    { 24, "Çorum" },
                    { 25, "Denizli" },
                    { 26, "Diyarbakır" },
                    { 27, "Düzce" },
                    { 28, "Edirne" },
                    { 29, "Elazığ" },
                    { 30, "Erzincan" },
                    { 31, "Erzurum" },
                    { 32, "Eskişehir" },
                    { 33, "Gaziantep" },
                    { 34, "Giresun" },
                    { 35, "Gümüşhane" },
                    { 36, "Hakkari" },
                    { 38, "Iğdır" },
                    { 39, "Isparta" },
                    { 42, "Kahramanmaraş" },
                    { 43, "Karabük" },
                    { 44, "Karaman" },
                    { 45, "Kars" },
                    { 47, "Kayseri" },
                    { 48, "Kırıkkale" },
                    { 49, "Kırklareli" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 50, "Kırşehir" },
                    { 51, "Kilis" },
                    { 52, "Kocaeli" },
                    { 53, "Konya" },
                    { 54, "Kütahya" },
                    { 55, "Malatya" },
                    { 56, "Manisa" },
                    { 57, "Mardin" },
                    { 58, "Mersin" },
                    { 59, "Muğla" },
                    { 60, "Muş" },
                    { 61, "Nevşehir" },
                    { 62, "Niğde" },
                    { 63, "Ordu" },
                    { 64, "Osmaniye" },
                    { 65, "Rize" },
                    { 66, "Sakarya" },
                    { 67, "Samsun" },
                    { 68, "Siirt" },
                    { 69, "Sinop" },
                    { 70, "Sivas" },
                    { 71, "Şanlıurfa" },
                    { 72, "Şırnak" },
                    { 73, "Tekirdağ" },
                    { 74, "Tokat" },
                    { 75, "Trabzon" },
                    { 76, "Tunceli" },
                    { 77, "Uşak" },
                    { 78, "Van" },
                    { 79, "Yalova" },
                    { 80, "Yozgat" },
                    { 81, "Zonguldak" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "Id",
                keyValue: 81);
        }
    }
}
