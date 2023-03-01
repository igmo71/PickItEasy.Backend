namespace PickItEasy.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(PickItEasyDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
