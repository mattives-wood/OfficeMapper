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
        public long SeatId { get; set; }
        public Seat Seat { get; set; }
    }
}
