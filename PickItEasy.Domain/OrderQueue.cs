using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain
{
    public class OrderQueue : EntityBase
    {
        public string? Name { get; set; }

        public Guid? OrderTypeId { get; set; }
        public OrderType? OrderType { get; set; }
    }
}
