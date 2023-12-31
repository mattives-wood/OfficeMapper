﻿// <auto-generated />
using System;
using GeoAPI.Geometries;
using MapperTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

namespace MapperTest.Data.Migrations
{
    [DbContext(typeof(MapperContext))]
    partial class MapperContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MapperTest.Domain.Fixture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<IPoint>("Coords")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<long>("FixtureTypeID");

                    b.Property<long>("MapId");

                    b.HasKey("Id");

                    b.HasIndex("FixtureTypeID");

                    b.HasIndex("MapId");

                    b.ToTable("Fixtures");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-316 2285)"),
                            FixtureTypeID = 1L,
                            MapId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-299 707.5)"),
                            FixtureTypeID = 1L,
                            MapId = 1L
                        });
                });

            modelBuilder.Entity("MapperTest.Domain.FixtureType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("FixtureTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Fire Extinguisher"
                        });
                });

            modelBuilder.Entity("MapperTest.Domain.Map", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Building")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Floor")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Maps");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Building = "Courthouse",
                            Description = "IT Deptartment",
                            Floor = "2"
                        });
                });

            modelBuilder.Entity("MapperTest.Domain.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Department");

                    b.Property<long>("EmployeeNumber");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("JobTitle");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long?>("SeatId");

                    b.Property<string>("SupervisorName");

                    b.HasKey("Id");

                    b.HasIndex("SeatId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 10415L,
                            FirstName = "Amy",
                            JobTitle = "3301-Director",
                            LastName = "Kaup",
                            SeatId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12296L,
                            FirstName = "Dan",
                            JobTitle = "3303-Programmer Analyst",
                            LastName = "Brandl",
                            SeatId = 2L,
                            SupervisorName = "Amy Kaup"
                        },
                        new
                        {
                            Id = 3L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 10527L,
                            FirstName = "Wendy",
                            JobTitle = "3303-Programmer Analyst",
                            LastName = "Markworth",
                            SeatId = 3L,
                            SupervisorName = "Amy Kaup"
                        },
                        new
                        {
                            Id = 4L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 10526L,
                            FirstName = "Chris",
                            JobTitle = "3311-Prog Anal/Web Develp",
                            LastName = "Markworth",
                            SeatId = 4L,
                            SupervisorName = "Amy Kaup"
                        },
                        new
                        {
                            Id = 5L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12489L,
                            FirstName = "Matt",
                            JobTitle = "3303-Programmer Analyst",
                            LastName = "Ives",
                            SeatId = 5L,
                            SupervisorName = "Amy Kaup"
                        },
                        new
                        {
                            Id = 6L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 10423L,
                            FirstName = "Lisa",
                            JobTitle = "3306-Software Specialist",
                            LastName = "Keller",
                            SeatId = 6L,
                            SupervisorName = "Amy Kaup"
                        },
                        new
                        {
                            Id = 7L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12252L,
                            FirstName = "Jason",
                            JobTitle = "3305-Netowrk Admin",
                            LastName = "DeMarco",
                            SeatId = 7L,
                            SupervisorName = "Amy Kaup"
                        },
                        new
                        {
                            Id = 8L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12244L,
                            FirstName = "Dave",
                            JobTitle = "3310-Network Analyst",
                            LastName = "Schreiber",
                            SeatId = 8L,
                            SupervisorName = "Jason DeMarco"
                        },
                        new
                        {
                            Id = 9L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12409L,
                            FirstName = "Phil",
                            JobTitle = "3310-Network Analyst",
                            LastName = "Anderson",
                            SeatId = 9L,
                            SupervisorName = "Jason DeMarco"
                        },
                        new
                        {
                            Id = 10L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12658L,
                            FirstName = "Carolynn",
                            JobTitle = "3305B-Systems Technician",
                            LastName = "Martin",
                            SeatId = 10L,
                            SupervisorName = "Jason DeMarco"
                        },
                        new
                        {
                            Id = 11L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12729L,
                            FirstName = "Jason",
                            JobTitle = "3305B-Systems Technician",
                            LastName = "McDonald",
                            SeatId = 11L,
                            SupervisorName = "Jason DeMarco"
                        },
                        new
                        {
                            Id = 12L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12726L,
                            FirstName = "Steven",
                            JobTitle = "3309-IT Intern",
                            LastName = "Xiong",
                            SeatId = 12L,
                            SupervisorName = "Jason DeMarco"
                        },
                        new
                        {
                            Id = 13L,
                            Department = "2701-Information Systems",
                            EmployeeNumber = 12725L,
                            FirstName = "Matt",
                            JobTitle = "3309-IT Intern",
                            LastName = "Thomas",
                            SeatId = 13L,
                            SupervisorName = "Jason DeMarco"
                        });
                });

            modelBuilder.Entity("MapperTest.Domain.PhoneNumber", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Number");

                    b.Property<long>("PersonId");

                    b.Property<long>("PhoneTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PhoneTypeId");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Number = 8435L,
                            PersonId = 1L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Number = 8545L,
                            PersonId = 2L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            Number = 8432L,
                            PersonId = 3L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            Number = 8409L,
                            PersonId = 4L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 5L,
                            Number = 8434L,
                            PersonId = 5L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 6L,
                            Number = 8560L,
                            PersonId = 6L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 7L,
                            Number = 8543L,
                            PersonId = 7L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 8L,
                            Number = 8449L,
                            PersonId = 8L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 9L,
                            Number = 8585L,
                            PersonId = 9L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 10L,
                            Number = 8433L,
                            PersonId = 10L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 11L,
                            Number = 8433L,
                            PersonId = 11L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 12L,
                            Number = 8433L,
                            PersonId = 12L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 13L,
                            Number = 8433L,
                            PersonId = 13L,
                            PhoneTypeId = 1L
                        },
                        new
                        {
                            Id = 14L,
                            Number = 7152134511L,
                            PersonId = 5L,
                            PhoneTypeId = 2L
                        },
                        new
                        {
                            Id = 15L,
                            Number = 7152139810L,
                            PersonId = 9L,
                            PhoneTypeId = 2L
                        },
                        new
                        {
                            Id = 16L,
                            Number = 7152139470L,
                            PersonId = 2L,
                            PhoneTypeId = 2L
                        });
                });

            modelBuilder.Entity("MapperTest.Domain.PhoneType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("phoneTypes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Office"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Cell"
                        });
                });

            modelBuilder.Entity("MapperTest.Domain.Seat", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Point>("Coords")
                        .IsRequired()
                        .HasColumnType("geometry");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("MapId");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("MapId");

                    b.ToTable("Seats");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-659 315.5)"),
                            Description = "Manager's Office",
                            MapId = 1L,
                            Number = 1
                        },
                        new
                        {
                            Id = 2L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-704 515.5)"),
                            Description = "Programmer Office 1",
                            MapId = 1L,
                            Number = 2
                        },
                        new
                        {
                            Id = 3L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-642 771)"),
                            Description = "Programmer Office 2",
                            MapId = 1L,
                            Number = 3
                        },
                        new
                        {
                            Id = 4L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-718 1089)"),
                            Description = "Programmer Office 3",
                            MapId = 1L,
                            Number = 4
                        },
                        new
                        {
                            Id = 5L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-702 1283)"),
                            Description = "Programmer Office 4",
                            MapId = 1L,
                            Number = 5
                        },
                        new
                        {
                            Id = 6L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-704 1597)"),
                            Description = "Application Specialist Office",
                            MapId = 1L,
                            Number = 6
                        },
                        new
                        {
                            Id = 7L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-702 1803)"),
                            Description = "Network Manager's Office",
                            MapId = 1L,
                            Number = 7
                        },
                        new
                        {
                            Id = 8L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-706 2103)"),
                            Description = "Network Specialist Office 1",
                            MapId = 1L,
                            Number = 8
                        },
                        new
                        {
                            Id = 9L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-716 2307)"),
                            Description = "Network Specialist Office 2",
                            MapId = 1L,
                            Number = 9
                        },
                        new
                        {
                            Id = 10L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-240 1249)"),
                            Description = "Help Desk 1",
                            MapId = 1L,
                            Number = 10
                        },
                        new
                        {
                            Id = 11L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-122 1253)"),
                            Description = "Help Desk 2",
                            MapId = 1L,
                            Number = 11
                        },
                        new
                        {
                            Id = 12L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-240 1661)"),
                            Description = "Help Desk 3",
                            MapId = 1L,
                            Number = 12
                        },
                        new
                        {
                            Id = 13L,
                            Coords = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=0;POINT (-116 1665)"),
                            Description = "Help Desk 4",
                            MapId = 1L,
                            Number = 13
                        });
                });

            modelBuilder.Entity("MapperTest.Domain.Fixture", b =>
                {
                    b.HasOne("MapperTest.Domain.FixtureType", "FixtureType")
                        .WithMany("Fixtures")
                        .HasForeignKey("FixtureTypeID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MapperTest.Domain.Map", "Map")
                        .WithMany("Fixtures")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MapperTest.Domain.Person", b =>
                {
                    b.HasOne("MapperTest.Domain.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId");
                });

            modelBuilder.Entity("MapperTest.Domain.PhoneNumber", b =>
                {
                    b.HasOne("MapperTest.Domain.Person", "Person")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MapperTest.Domain.PhoneType", "PhoneType")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("PhoneTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MapperTest.Domain.Seat", b =>
                {
                    b.HasOne("MapperTest.Domain.Map", "Map")
                        .WithMany("Seats")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
