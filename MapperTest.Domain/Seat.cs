using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace MapperTest.Domain
{
    public class Seat
    {
        public Seat()
        {
        }

        public long Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public long MapId { get; set; }
        public Map Map { get; set; }
        public Point Coords { get; set; }
    }
}
