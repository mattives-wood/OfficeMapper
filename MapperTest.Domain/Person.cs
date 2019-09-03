using System.Collections.Generic;

namespace MapperTest.Domain
{
    public class Person
    {
        public Person()
        {
            PhoneNumbers = new List<PhoneNumber>();
        }

        public long Id { get; set; }
        public long EmployeeNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string SupervisorName { get; set; }
        public string Department { get; set; }
        public long? SeatId { get; set; }
        public Seat Seat { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
    }
}
