using PickItEasy.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.UnitTests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly PickItEasyDbContext Context;

        public TestCommandBase()
        {
            Context = PickItEasyContextFactory.Create();
        }

        public void Dispose()
        {
            PickItEasyContextFactory.Destroy(Context);
        }
    }
}
