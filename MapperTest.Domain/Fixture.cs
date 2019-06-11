using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapperTest.Domain
{
    public class Fixture
    {
        public Fixture()
        {
        }

        public long Id { get; set; }
        //Name?
        public long FixtureTypeID { get; set; }
        public FixtureType FixtureType { get; set; }
        public long MapId { get; set; }
        public Map Map { get; set; }
        //public decimal CoordX { get; set; }
        //public decimal CoordY { get; set; }
        public IPoint Coords { get; set; }
    }
}
