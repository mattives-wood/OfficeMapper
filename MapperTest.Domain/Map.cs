using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapperTest.Domain
{
    public class Map
    {
        public Map()
        {
            Seats = new List<Seat>();
            Fixtures = new List<Fixture>();
        }

        public long Id { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Description { get; set; }
        public List<Seat> Seats { get; set; }
        public List<Fixture> Fixtures { get; set; }
    }
}
