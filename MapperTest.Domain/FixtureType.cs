using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapperTest.Domain
{
    public class FixtureType
    {
        public FixtureType()
        {
            Fixtures = new List<Fixture>();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public List<Fixture> Fixtures { get; set; }
    }
}
