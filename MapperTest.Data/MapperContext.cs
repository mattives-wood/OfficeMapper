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

            modelBuilder.Entity<Person>(ep =>
                ep.Property(p => p.MapId).IsRequired()
            );

            modelBuilder.Entity<Person>(ep =>
            {
                ep.Property(p => p.Coords)
                    .HasColumnType("geometry")
                    .IsRequired();
            });

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

            #region Seed Data
            GeoAPI.Geometries.IGeometryFactory geoFactory = NetTopologySuite.NtsGeometryServices.Instance.CreateGeometryFactory();
            modelBuilder.Entity<Map>().HasData(new Map { Id = 1, Building = "Courthouse", Floor = "2", Description = "IT Deptartment" });
            modelBuilder.Entity<FixtureType>().HasData(new FixtureType { Id = 1, Description = "Fire Extinguisher" });
            //modelBuilder.Entity<Fixture>().HasData(new Fixture { Id = 1, FixtureTypeID = 1, MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-316, 2285) });
            //modelBuilder.Entity<Fixture>().HasData(new Fixture { Id = 2, FixtureTypeID = 1, MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-299, 707.5) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 1, FirstName = "Amy", LastName = "Kaup", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-659, 315.5) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 2, FirstName = "Dan", LastName = "Brandl", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-704, 515.5) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 3, FirstName = "Wendy", LastName = "Markworth", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-642, 771) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 4, FirstName = "Chris", LastName = "Markworth", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-718, 1089) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 5, FirstName = "Matt", LastName = "Ives", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-702, 1283) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 6, FirstName = "Lisa", LastName = "Keller", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-704, 1597) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 7, FirstName = "Jason", LastName = "DeMarco", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-702, 1803) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 8, FirstName = "Dave", LastName = "Schreiber", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-706, 2103) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 9, FirstName = "Phil", LastName = "Anderson", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-716, 2307) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 10, FirstName = "Carolynn", LastName = "Martin", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-240, 1249) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 11, FirstName = "Jason", LastName = "McDonald", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-122, 1253) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 12, FirstName = "Steven", LastName = "Xiong", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-240, 1661) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 13, FirstName = "Matt", LastName = "Thomas", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-116, 1665) });
            modelBuilder.Entity<Fixture>().HasData(new Fixture { Id = 1, FixtureTypeID = 1, MapId = 1, Coords = geoFactory.CreatePoint(new GeoAPI.Geometries.Coordinate(-316, 2285)) });
            //modelBuilder.Entity<Fixture>().HasData(new Fixture { Id = 2, FixtureTypeID = 1, MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-299, 707.5) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 1, FirstName = "Amy", LastName = "Kaup", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-659, 315.5) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 2, FirstName = "Dan", LastName = "Brandl", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-704, 515.5) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 3, FirstName = "Wendy", LastName = "Markworth", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-642, 771) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 4, FirstName = "Chris", LastName = "Markworth", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-718, 1089) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 5, FirstName = "Matt", LastName = "Ives", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-702, 1283) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 6, FirstName = "Lisa", LastName = "Keller", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-704, 1597) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 7, FirstName = "Jason", LastName = "DeMarco", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-702, 1803) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 8, FirstName = "Dave", LastName = "Schreiber", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-706, 2103) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 9, FirstName = "Phil", LastName = "Anderson", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-716, 2307) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 10, FirstName = "Carolynn", LastName = "Martin", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-240, 1249) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 11, FirstName = "Jason", LastName = "McDonald", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-122, 1253) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 12, FirstName = "Steven", LastName = "Xiong", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-240, 1661) });
            //modelBuilder.Entity<Person>().HasData(new Person { Id = 13, FirstName = "Matt", LastName = "Thomas", MapId = 1, Coords = new NetTopologySuite.Geometries.Point(-116, 1665) });
            #endregion
        }
    }
}