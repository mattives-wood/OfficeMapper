using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapperTest.Domain
{
    public class Map
    {
        public Map()
        {
            Persons = new List<Person>();
            Fixtures = new List<Fixture>();
        }

        public long Id { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Description { get; set; }
        public List<Person> Persons { get; set; }
        public List<Fixture> Fixtures { get; set; }
    }
}
