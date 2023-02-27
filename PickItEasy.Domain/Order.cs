using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain
{
    public class Order : EntityBase
    {
        public Order()
        {
            OrderDetails = new();
        }

        public string? Number { get; set; }
        public DateTime Date { get; set; }

        public Guid? OrderStatusId { get; set; }
        public OrderStatus? OrderStatus { get; set; }

        public Guid? OrderQueueId { get; set; }
        public OrderQueue? OrderQueue { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
