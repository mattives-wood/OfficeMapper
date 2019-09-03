using System.Collections.Generic;

namespace MapperTest.Domain
{
    public class PhoneType
    {
        public PhoneType()
        {
            PhoneNumbers = new List<PhoneNumber>();
        }

        public long Id { get; set; }
        public string Description { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
