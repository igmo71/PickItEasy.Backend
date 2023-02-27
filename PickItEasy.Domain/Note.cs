using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain
{
    public class Note : EntityBase
    {
        public Guid UserId { get; set; }
        public string? Title { get; set; }
        public string? Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
    }
}
