namespace Shopping_Application.Models
{
    public class CartDetail
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid IdSp { get; set; }
        public int Quantity { get; set; }

    }
}
