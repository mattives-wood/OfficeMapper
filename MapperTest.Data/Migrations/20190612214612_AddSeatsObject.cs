using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace MapperTest.Data.Migrations
{
    public partial class AddSeatsObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Maps_MapId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Coords",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "MapId",
                table: "Persons",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_MapId",
                table: "Persons",
                newName: "IX_Persons_SeatId");

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

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L,
                column: "SeatId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3L,
                column: "SeatId",
                value: 3L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4L,
                column: "SeatId",
                value: 4L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5L,
                column: "SeatId",
                value: 5L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6L,
                column: "SeatId",
                value: 6L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7L,
                column: "SeatId",
                value: 7L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8L,
                column: "SeatId",
                value: 8L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9L,
                column: "SeatId",
                value: 9L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10L,
                column: "SeatId",
                value: 10L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 11L,
                column: "SeatId",
                value: 11L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 12L,
                column: "SeatId",
                value: 12L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 13L,
                column: "SeatId",
                value: 13L);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_MapId",
                table: "Seats",
                column: "MapId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Seats_SeatId",
                table: "Persons",
                column: "SeatId",
                principalTable: "Seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Seats_SeatId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Persons",
                newName: "MapId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_SeatId",
                table: "Persons",
                newName: "IX_Persons_MapId");

            migrationBuilder.AddColumn<Point>(
                name: "Coords",
                table: "Persons",
                type: "geometry",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Coords",
                value: (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-659 315.5)"));

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-704 515.5)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-642 771)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-718 1089)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-702 1283)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-704 1597)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-702 1803)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-706 2103)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-716 2307)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-240 1249)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-122 1253)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-240 1661)"), 1L });

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "Coords", "MapId" },
                values: new object[] { (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-116 1665)"), 1L });

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Maps_MapId",
                table: "Persons",
                column: "MapId",
                principalTable: "Maps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
