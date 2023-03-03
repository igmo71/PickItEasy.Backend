using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Notes.Commands.CreateNote;
using PickItEasy.Application.Notes.Commands.DeleteNote;
using PickItEasy.Application.Notes.Queries.Notes.GetNoteDetails;
using PickItEasy.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.UnitTests.Notes.Commands
{
    public class DeleteNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteNoteCommand
            {
                Id = PickItEasyContextFactory.NoteIdForDelete,
                UserId = PickItEasyContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(await Context.Notes.SingleOrDefaultAsync(note =>
                note.Id == PickItEasyContextFactory.NoteIdForDelete));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteNoteCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new DeleteNoteCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = PickItEasyContextFactory.UserAId
                }, CancellationToken.None));
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var createHandler = new CreateNoteCommandHandler(Context);
            var deleteHandler = new DeleteNoteCommandHandler(Context);

            // Act
            var noteId = await createHandler.Handle(
                new CreateNoteCommand
                {
                    UserId = PickItEasyContextFactory.UserAId,
                    Title = "NoteTitle",
                    Details = "NoteDetails"
                }, CancellationToken.None);

            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(new DeleteNoteCommand
                {
                    Id = noteId,
                    UserId = PickItEasyContextFactory.UserBId
                }, CancellationToken.None));
        }
    }
}
