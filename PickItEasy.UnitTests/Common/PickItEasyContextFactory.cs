using Microsoft.EntityFrameworkCore;
using PickItEasy.Domain;
using PickItEasy.Persistence;

namespace PickItEasy.UnitTests.Common
{
    public class PickItEasyContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid NoteIdForDelete = Guid.NewGuid();
        public static Guid NoteIdForUpdate = Guid.NewGuid();

        public static PickItEasyDbContext Create()
        {
            var options = new DbContextOptionsBuilder<PickItEasyDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new PickItEasyDbContext(options);
            context.Database.EnsureCreated();
            context.Notes.AddRange(
                new Note
                {
                    Id = Guid.Parse("7998A8AB-A149-42E2-AB79-A68E92F87BCE"),
                    UserId = UserAId,
                    Title = "Title1",
                    Details = "Details1",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Id = Guid.Parse("384E9C7B-D248-47D2-845B-2614D585C53A"),
                    UserId = UserBId,
                    Title = "Title2",
                    Details = "Details2",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Id = NoteIdForDelete,
                    UserId = UserAId,
                    Title = "Title3",
                    Details = "Details3",
                    CreationDate = DateTime.Today,
                    EditDate = null
                },
                new Note
                {
                    Id = NoteIdForUpdate,
                    UserId = UserBId,
                    Title = "Title4",
                    Details = "Details4",
                    CreationDate = DateTime.Today,
                    EditDate = null
                });
            context.SaveChanges();
            return context;
        }

        public static void Destroy(PickItEasyDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
