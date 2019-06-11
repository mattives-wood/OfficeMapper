using NetTopologySuite.Geometries;

namespace MapperTest.Domain
{
    public class Person
    {
        public Person()
        {
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //picture
        public long MapId { get; set; }
        public Map Map { get; set; }
        //public decimal CoordX { get; set; }
        //public decimal CoordY { get; set; }
        public Point Coords { get; set; }
    }
}
