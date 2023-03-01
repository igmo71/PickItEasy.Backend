namespace PickItEasy.Domain
{
    public class OrderDetailHistory : EntityBase
    {
        public DateTime EditDate { get; set; }

        public Guid OrderDetailId { get; set; }
        public OrderDetail? OrderDetail { get; set; }

        //public Guid UserId { get; set; }
        //public ApplicationUser User { get; set; }

        public float LastCount { get; set; }
        public float NewCount { get; set; }
    }
}
