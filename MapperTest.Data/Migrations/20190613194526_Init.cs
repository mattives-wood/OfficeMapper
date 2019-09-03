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
                name: "phoneTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phoneTypes", x => x.Id);
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
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    MapId = table.Column<long>(nullable: false),
                    Coords = table.Column<Point>(type: "geometry", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Maps_MapId",
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
                    EmployeeNumber = table.Column<long>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    JobTitle = table.Column<string>(nullable: true),
                    SupervisorName = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    SeatId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<long>(nullable: false),
                    Number = table.Column<long>(nullable: false),
                    PhoneTypeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_phoneTypes_PhoneTypeId",
                        column: x => x.PhoneTypeId,
                        principalTable: "phoneTypes",
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
                table: "phoneTypes",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1L, "Office" },
                    { 2L, "Cell" }
                });

            migrationBuilder.InsertData(
                table: "Fixtures",
                columns: new[] { "Id", "Coords", "FixtureTypeID", "MapId" },
                values: new object[,]
                {
                    { 1L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-316 2285)"), 1L, 1L },
                    { 2L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-299 707.5)"), 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Coords", "Description", "MapId", "Number" },
                values: new object[,]
                {
                    { 1L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-659 315.5)"), "Manager's Office", 1L, 1 },
                    { 2L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-704 515.5)"), "Programmer Office 1", 1L, 2 },
                    { 3L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-642 771)"), "Programmer Office 2", 1L, 3 },
                    { 4L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-718 1089)"), "Programmer Office 3", 1L, 4 },
                    { 5L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-702 1283)"), "Programmer Office 4", 1L, 5 },
                    { 6L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-704 1597)"), "Application Specialist Office", 1L, 6 },
                    { 7L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-702 1803)"), "Network Manager's Office", 1L, 7 },
                    { 8L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-706 2103)"), "Network Specialist Office 1", 1L, 8 },
                    { 9L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-716 2307)"), "Network Specialist Office 2", 1L, 9 },
                    { 10L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-240 1249)"), "Help Desk 1", 1L, 10 },
                    { 11L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-122 1253)"), "Help Desk 2", 1L, 11 },
                    { 12L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-240 1661)"), "Help Desk 3", 1L, 12 },
                    { 13L, (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-116 1665)"), "Help Desk 4", 1L, 13 }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Department", "EmployeeNumber", "FirstName", "JobTitle", "LastName", "SeatId", "SupervisorName" },
                values: new object[,]
                {
                    { 1L, "2701-Information Systems", 10415L, "Amy", "3301-Director", "Kaup", 1L, null },
                    { 2L, "2701-Information Systems", 12296L, "Dan", "3303-Programmer Analyst", "Brandl", 2L, "Amy Kaup" },
                    { 3L, "2701-Information Systems", 10527L, "Wendy", "3303-Programmer Analyst", "Markworth", 3L, "Amy Kaup" },
                    { 4L, "2701-Information Systems", 10526L, "Chris", "3311-Prog Anal/Web Develp", "Markworth", 4L, "Amy Kaup" },
                    { 5L, "2701-Information Systems", 12489L, "Matt", "3303-Programmer Analyst", "Ives", 5L, "Amy Kaup" },
                    { 6L, "2701-Information Systems", 10423L, "Lisa", "3306-Software Specialist", "Keller", 6L, "Amy Kaup" },
                    { 7L, "2701-Information Systems", 12252L, "Jason", "3305-Netowrk Admin", "DeMarco", 7L, "Amy Kaup" },
                    { 8L, "2701-Information Systems", 12244L, "Dave", "3310-Network Analyst", "Schreiber", 8L, "Jason DeMarco" },
                    { 9L, "2701-Information Systems", 12409L, "Phil", "3310-Network Analyst", "Anderson", 9L, "Jason DeMarco" },
                    { 10L, "2701-Information Systems", 12658L, "Carolynn", "3305B-Systems Technician", "Martin", 10L, "Jason DeMarco" },
                    { 11L, "2701-Information Systems", 12729L, "Jason", "3305B-Systems Technician", "McDonald", 11L, "Jason DeMarco" },
                    { 12L, "2701-Information Systems", 12726L, "Steven", "3309-IT Intern", "Xiong", 12L, "Jason DeMarco" },
                    { 13L, "2701-Information Systems", 12725L, "Matt", "3309-IT Intern", "Thomas", 13L, "Jason DeMarco" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Number", "PersonId", "PhoneTypeId" },
                values: new object[,]
                {
                    { 1L, 8435L, 1L, 1L },
                    { 2L, 8545L, 2L, 1L },
                    { 16L, 7152139470L, 2L, 2L },
                    { 3L, 8432L, 3L, 1L },
                    { 4L, 8409L, 4L, 1L },
                    { 5L, 8434L, 5L, 1L },
                    { 14L, 7152134511L, 5L, 2L },
                    { 6L, 8560L, 6L, 1L },
                    { 7L, 8543L, 7L, 1L },
                    { 8L, 8449L, 8L, 1L },
                    { 9L, 8585L, 9L, 1L },
                    { 15L, 7152139810L, 9L, 2L },
                    { 10L, 8433L, 10L, 1L },
                    { 11L, 8433L, 11L, 1L },
                    { 12L, 8433L, 12L, 1L },
                    { 13L, 8433L, 13L, 1L }
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
                name: "IX_Persons_SeatId",
                table: "Persons",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PersonId",
                table: "PhoneNumbers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_PhoneTypeId",
                table: "PhoneNumbers",
                column: "PhoneTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_MapId",
                table: "Seats",
                column: "MapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fixtures");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "FixtureTypes");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "phoneTypes");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Maps");
        }
    }
}
