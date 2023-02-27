namespace PickItEasy.Domain
{
    public class OrderDetail : EntityBase
    {
        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public Guid? ProductId { get; set; }
        public Product? Product { get; set; }

        public float Count { get; set; }
    }
}