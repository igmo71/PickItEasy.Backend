namespace PickItEasy.Domain
{
    public class OrderHistory : EntityBase
    {
        public DateTime EditDate { get; set; }

        public Guid OrderId { get; set; }
        public Order? Order { get; set; }

        //public Guid UserId { get; set; }
        //public ApplicationUser User { get; set; }

        public Guid? NewOrderStatusId { get; set; }
        public OrderStatus? NewOrderStatus { get; set; }
    }
}
