using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Domain
{
    public class Product : EntityBase
    {
        public string? Name { get; set; }
        public bool IsDelete { get; set; }
    }
}
