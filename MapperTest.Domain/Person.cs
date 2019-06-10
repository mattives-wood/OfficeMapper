using System;

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
        public int MapId { get; set; }
        //public decimal CoordX { get; set; }
        //public decimal CoordY { get; set; }
        public SpatialData
    }
}
