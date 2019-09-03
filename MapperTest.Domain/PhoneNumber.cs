namespace MapperTest.Domain
{
    public class PhoneNumber
    {
        public PhoneNumber()
        {
        }

        public long Id { get; set; }
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public long Number { get; set; }
        public long PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}
