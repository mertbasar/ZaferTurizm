using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class InsOlur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleModel",
                columns: new[] { "Id", "Name", "VehicleMakeId" },
                values: new object[,]
                {
                    { 20, "Focus", 1 },
                    { 21, "Octavia", 1 },
                    { 22, "404", 1 },
                    { 23, "Arda", 1 },
                    { 24, "BBara", 1 },
                    { 25, "Merdo", 1 }
                });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "HasToilet", "HasWifi", "SeatCount", "VehicleModelId", "AracınUretimYili" },
                values: new object[] { 1, true, false, 25, 20, "2020" });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "HasToilet", "HasWifi", "SeatCount", "VehicleModelId", "AracınUretimYili" },
                values: new object[] { 2, true, true, 48, 20, "2022" });

            migrationBuilder.InsertData(
                table: "VehicleDefinition",
                columns: new[] { "Id", "HasToilet", "HasWifi", "SeatCount", "VehicleModelId", "AracınUretimYili" },
                values: new object[] { 3, true, true, 52, 23, "2023" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleDefinition",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "VehicleModel",
                keyColumn: "Id",
                keyValue: 23);
        }
    }
}
