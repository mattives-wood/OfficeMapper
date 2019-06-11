using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace MapperTest.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FixtureTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixtureTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Building = table.Column<string>(maxLength: 50, nullable: true),
                    Floor = table.Column<string>(maxLength: 10, nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fixtures",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FixtureTypeID = table.Column<long>(nullable: false),
                    MapId = table.Column<long>(nullable: false),
                    Coords = table.Column<IPoint>(type: "geometry", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fixtures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fixtures_FixtureTypes_FixtureTypeID",
                        column: x => x.FixtureTypeID,
                        principalTable: "FixtureTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fixtures_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    MapId = table.Column<long>(nullable: false),
                    Coords = table.Column<Point>(type: "geometry", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Maps_MapId",
                        column: x => x.MapId,
                        principalTable: "Maps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FixtureTypes",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1L, "Fire Extinguisher" });

            migrationBuilder.InsertData(
                table: "Maps",
                columns: new[] { "Id", "Building", "Description", "Floor" },
                values: new object[] { 1L, "Courthouse", "IT Deptartment", "2" });

            migrationBuilder.InsertData(
                table: "Fixtures",
                columns: new[] { "Id", "Coords", "FixtureTypeID", "MapId" },
                values: new object[] { 1L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("POINT (-316 2285)"), 1L, 1L });

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_FixtureTypeID",
                table: "Fixtures",
                column: "FixtureTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Fixtures_MapId",
                table: "Fixtures",
                column: "MapId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_MapId",
                table: "Persons",
                column: "MapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "FixtureTypes");

            migrationBuilder.DropTable(
                name: "Maps");
        }
    }
}
