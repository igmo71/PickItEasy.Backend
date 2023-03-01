namespace PickItEasy.Domain
{
    public class OrderStatus : EntityBase
    {
        public string? Name { get; set; }

        public Guid? OrderTypeId { get; set; }
        public OrderType? OrderType { get; set; }
    }
}
