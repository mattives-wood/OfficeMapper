using MapperTest.Domain;
using Microsoft.EntityFrameworkCore;

namespace MapperTest.Data
{
    public class MapperContext : DbContext
    {
        public MapperContext(DbContextOptions<MapperContext> options) : base(options) { }

        public DbSet<Map> Maps { get; set; }
        public DbSet<FixtureType> FixtureTypes { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fixture>(ef =>
            {
                ef.Property(f => f.FixtureTypeID).IsRequired();
            });

            modelBuilder.Entity<Fixture>(ef =>
            {
                ef.Property(f => f.MapId).IsRequired();
            });

            modelBuilder.Entity<Fixture>(ef =>
            {
                ef.Property(f => f.Coords)
                    .HasColumnType("geometry")
                    .IsRequired();
            });

            modelBuilder.Entity<Person>(ep =>
                ep.Property(p => p.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
            );

            modelBuilder.Entity<Person>(ep =>
                ep.Property(p => p.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
            );

            modelBuilder.Entity<FixtureType>(eft =>
            {
                eft.Property(ft => ft.Description)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Map>(em =>
            {
                em.Property(m => m.Building).HasMaxLength(50);
            });

            modelBuilder.Entity<Map>(em =>
            {
                em.Property(m => m.Floor).HasMaxLength(10);
            });

            modelBuilder.Entity<Map>(em =>
            {
                em.Property(m => m.Description)
                    .HasMaxLength(100)
                    .IsRequired();
            });

            modelBuilder.Entity<Seat>(es =>
            {
                es.Property(s => s.Number).IsRequired();
            });

            modelBuilder.Entity<Seat>(es =>
            {
                es.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(100);
            });

            modelBuilder.Entity<Seat>(es =>
            {
                es.Property(s => s.MapId).IsRequired();
            });

            modelBuilder.Entity<Seat>(es =>
            {
                es.Property(s => s.Coords)
                .HasColumnType("geometry")
                .IsRequired();
            });

            #region Seed Data
            GeoAPI.Geometries.IGeometryFactory geoFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory(4326);
            modelBuilder.Entity<Map>().HasData(new Map { Id = 1, Building = "Courthouse", Floor = "2", Description = "IT Deptartment" });
            modelBuilder.Entity<FixtureType>().HasData(new FixtureType { Id = 1, Description = "Fire Extinguisher" });
            modelBuilder.Entity<Fixture>().HasData(new Fixture { Id = 1, FixtureTypeID = 1, MapId = 1, Coords = geoFactory.CreatePoint(new GeoAPI.Geometries.Coordinate(-316, 2285)) });
            modelBuilder.Entity<Fixture>().HasData(new Fixture { Id = 2, FixtureTypeID = 1, MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-299, 707.5) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 1, Number = 001, MapId = 1, Description = "Manager's Office", Coords = new NetTopologySuite.Geometries.Point(-659, 315.5) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 2, Number = 002, MapId = 1, Description = "Programmer Office 1", Coords = new NetTopologySuite.Geometries.Point(-704, 515.5) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 3, Number = 003, MapId = 1, Description = "Programmer Office 2", Coords = new NetTopologySuite.Geometries.Point(-642, 771) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 4, Number = 004, MapId = 1, Description = "Programmer Office 3", Coords = new NetTopologySuite.Geometries.Point(-718, 1089) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 5, Number = 005, MapId = 1, Description = "Programmer Office 4", Coords = new NetTopologySuite.Geometries.Point(-702, 1283) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 6, Number = 006, MapId = 1, Description = "Application Specialist Office", Coords = new NetTopologySuite.Geometries.Point(-704, 1597) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 7, Number = 007, MapId = 1, Description = "Network Manager's Office", Coords = new NetTopologySuite.Geometries.Point(-702, 1803) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 8, Number = 008, MapId = 1, Description = "Network Specialist Office 1", Coords = new NetTopologySuite.Geometries.Point(-706, 2103) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 9, Number = 009, MapId = 1, Description = "Network Specialist Office 2", Coords = new NetTopologySuite.Geometries.Point(-716, 2307) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 10, Number = 010, MapId = 1, Description = "Help Desk 1", Coords = new NetTopologySuite.Geometries.Point(-240, 1249) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 11, Number = 011, MapId = 1, Description = "Help Desk 2", Coords = new NetTopologySuite.Geometries.Point(-122, 1253) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 12, Number = 012, MapId = 1, Description = "Help Desk 3", Coords = new NetTopologySuite.Geometries.Point(-240, 1661) });
            modelBuilder.Entity<Seat>().HasData(new Seat { Id = 13, Number = 013, MapId = 1, Description = "Help Desk 4", Coords = new NetTopologySuite.Geometries.Point(-116, 1665) });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 1, FirstName = "Amy", LastName = "Kaup", SeatId = 1 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 2, FirstName = "Dan", LastName = "Brandl", SeatId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 3, FirstName = "Wendy", LastName = "Markworth", SeatId = 3 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 4, FirstName = "Chris", LastName = "Markworth", SeatId = 4 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 5, FirstName = "Matt", LastName = "Ives", SeatId = 5 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 6, FirstName = "Lisa", LastName = "Keller", SeatId = 6 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 7, FirstName = "Jason", LastName = "DeMarco", SeatId = 7 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 8, FirstName = "Dave", LastName = "Schreiber", SeatId = 8 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 9, FirstName = "Phil", LastName = "Anderson", SeatId = 9 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 10, FirstName = "Carolynn", LastName = "Martin", SeatId = 10 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 11, FirstName = "Jason", LastName = "McDonald", SeatId = 11 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 12, FirstName = "Steven", LastName = "Xiong", SeatId = 12 });
            modelBuilder.Entity<Person>().HasData(new Person { Id = 13, FirstName = "Matt", LastName = "Thomas", SeatId = 13 });
            #endregion
        }
    }
}