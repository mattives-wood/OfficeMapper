using GeoAPI.Geometries;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace MapperTest.Data.Migrations
{
    public partial class Init : Migration
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
                values: new object[,]
                {
                    { 1L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-316 2285)"), 1L, 1L },
                    { 2L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-299 707.5)"), 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Coords", "FirstName", "LastName", "MapId" },
                values: new object[,]
                {
                    { 1L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-659 315.5)"), "Amy", "Kaup", 1L },
                    { 2L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-704 515.5)"), "Dan", "Brandl", 1L },
                    { 3L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-642 771)"), "Wendy", "Markworth", 1L },
                    { 4L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-718 1089)"), "Chris", "Markworth", 1L },
                    { 5L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-702 1283)"), "Matt", "Ives", 1L },
                    { 6L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-704 1597)"), "Lisa", "Keller", 1L },
                    { 7L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-702 1803)"), "Jason", "DeMarco", 1L },
                    { 8L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-706 2103)"), "Dave", "Schreiber", 1L },
                    { 9L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-716 2307)"), "Phil", "Anderson", 1L },
                    { 10L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-240 1249)"), "Carolynn", "Martin", 1L },
                    { 11L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-122 1253)"), "Jason", "McDonald", 1L },
                    { 12L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-240 1661)"), "Steven", "Xiong", 1L },
                    { 13L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-116 1665)"), "Matt", "Thomas", 1L }
                });

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
