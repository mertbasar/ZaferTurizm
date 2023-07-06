using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaferTurizm.DataAccess.Migrations
{
    public partial class VehicleInsLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passenger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(20)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(20)", nullable: false),
                    IdentityNumber = table.Column<string>(type: "varchar(20)", nullable: true),
                    Cinsiyet = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passenger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartureCityId = table.Column<int>(type: "int", nullable: false),
                    ArrivalCityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_City_ArrivalCityId",
                        column: x => x.ArrivalCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Route_City_DepartureCityId",
                        column: x => x.DepartureCityId,
                        principalTable: "City",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BusTrip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusTrip_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BusTrip_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusTripId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_BusTrip_BusTripId",
                        column: x => x.BusTripId,
                        principalTable: "BusTrip",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ticket_Passenger_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "Passenger",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana" },
                    { 7, "Ankara" },
                    { 8, "Antalya" },
                    { 37, "Hatay" },
                    { 40, "İstanbul" },
                    { 41, "İzmir" },
                    { 46, "Kastamonu" }
                });

            migrationBuilder.InsertData(
                table: "Passenger",
                columns: new[] { "Id", "Age", "FirstName", "Cinsiyet", "IdentityNumber", "LastName", "PhoneNumber" },
                values: new object[] { 1, 31, "Arda", 2, "", "Korkmaz", "05552313234" });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "ArrivalCityId", "DepartureCityId" },
                values: new object[,]
                {
                    { 1, 40, 41 },
                    { 2, 37, 40 },
                    { 3, 46, 8 },
                    { 4, 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "BusTrip",
                columns: new[] { "Id", "Date", "Price", "RouteId", "VehicleId" },
                values: new object[] { 1, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 200m, 2, 1 });

            migrationBuilder.InsertData(
                table: "Ticket",
                columns: new[] { "Id", "BusTripId", "PaidAmount", "PassengerId", "SeatNumber" },
                values: new object[] { 1, 1, 200m, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_RouteId",
                table: "BusTrip",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTrip_VehicleId",
                table: "BusTrip",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_ArrivalCityId",
                table: "Route",
                column: "ArrivalCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DepartureCityId",
                table: "Route",
                column: "DepartureCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BusTripId",
                table: "Ticket",
                column: "BusTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PassengerId",
                table: "Ticket",
                column: "PassengerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "BusTrip");

            migrationBuilder.DropTable(
                name: "Passenger");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
