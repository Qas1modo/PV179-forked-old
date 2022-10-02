namespace DAL.Models
{
    public class CartItem : BaseEntity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int BookId { get; set; }

        public virtual Book Book { get; set; }

    }
}
