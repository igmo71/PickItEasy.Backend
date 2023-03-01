using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PickItEasyDbContext context) {
            context.Database.EnsureCreated();
        }
    }
}
