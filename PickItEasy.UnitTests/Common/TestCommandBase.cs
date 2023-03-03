using PickItEasy.Persistence;

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
