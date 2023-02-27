using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PickItEasyDbConterxt context) {
            context.Database.EnsureCreated();
        }
    }
}
