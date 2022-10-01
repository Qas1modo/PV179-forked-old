namespace DAL.Models
{
    public class Address : BaseEntity
    {
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public int StNumber { get; set; }
        
        public int ZipCode { get; set; }

    }
}
