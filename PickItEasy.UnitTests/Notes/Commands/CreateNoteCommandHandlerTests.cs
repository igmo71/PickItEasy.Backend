using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Notes.Commands.CreateNote;
using PickItEasy.UnitTests.Common;

namespace PickItEasy.UnitTests.Notes.Commands
{
    public class CreateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateNoteCommandHabdler_Success()
        {
            // Arrange
            var handler = new CreateNoteCommandHandler(Context);
            var noteName = "note name";
            var noteDetails = "note detail";

            // Act
            var noteId = await handler.Handle(
                new CreateNoteCommand
                {
                    UserId = PickItEasyContextFactory.UserAId,
                    Title = noteName,
                    Details = noteDetails
                }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note =>
                note.Id == noteId && note.Title == noteName && note.Details == noteDetails));

        }
    }
}
