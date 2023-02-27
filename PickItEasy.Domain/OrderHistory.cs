using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain
{
    public class OrderHistory : EntityBase
    {
        public Guid OrderDetailId { get; set; }
        public DateTime EditDate { get; set; }
        public float LastCount { get; set; }
        public float NewCount { get; set; }
    }
}
