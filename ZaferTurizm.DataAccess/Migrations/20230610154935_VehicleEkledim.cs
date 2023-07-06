using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class VehicleEkledim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagesUrl",
                table: "Vehicle",
                type: "varchar(1000)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "ImagesUrl", "PlateNumber", "VehicleDefinitionId" },
                values: new object[,]
                {
                    { 1, "", "34 ABC 34", 1 },
                    { 2, "", "34 MRT 34", 2 },
                    { 3, "", "34 BSR 34", 3 },
                    { 4, "", "31 MST 31", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ImagesUrl",
                table: "Vehicle");
        }
    }
}
