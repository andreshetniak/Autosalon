using Microsoft.EntityFrameworkCore.Migrations;

namespace Autosalon.WebHost.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(maxLength: 50, nullable: false),
                    Model = table.Column<string>(maxLength: 50, nullable: false),
                    Year = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MainImage = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriveUnitType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriveUnitType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarkAndModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Mark = table.Column<string>(maxLength: 50, nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkAndModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransmissionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransmissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCar = table.Column<int>(nullable: false),
                    Transmission = table.Column<int>(nullable: true),
                    Fuel = table.Column<int>(nullable: true),
                    DriveUnit = table.Column<int>(nullable: true),
                    EngineVolume = table.Column<decimal>(type: "decimal(3, 1)", nullable: true),
                    Horsepower = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characteristics_DriveUnitType",
                        column: x => x.DriveUnit,
                        principalTable: "DriveUnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characteristics_FuelType",
                        column: x => x.Fuel,
                        principalTable: "FuelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Characteristics_Car",
                        column: x => x.IdCar,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characteristics_TransmissionType",
                        column: x => x.Transmission,
                        principalTable: "TransmissionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_DriveUnit",
                table: "Characteristics",
                column: "DriveUnit");

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_Fuel",
                table: "Characteristics",
                column: "Fuel");

            migrationBuilder.CreateIndex(
                name: "AK_IdCar",
                table: "Characteristics",
                column: "IdCar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_Transmission",
                table: "Characteristics",
                column: "Transmission");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.DropTable(
                name: "MarkAndModel");

            migrationBuilder.DropTable(
                name: "DriveUnitType");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "TransmissionType");
        }
    }
}
