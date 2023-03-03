using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Application.Notes.Commands.UpdateNote;
using PickItEasy.UnitTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.UnitTests.Notes.Commands
{
    public class UpdateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateNoteCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(Context);
            var updatedTitle = "new Title";

            // Act
            await handler.Handle(new UpdateNoteCommand
            {
                Id = PickItEasyContextFactory.NoteIdForUpdate,
                UserId = PickItEasyContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note =>
                note.Id == PickItEasyContextFactory.NoteIdForUpdate && note.Title == updatedTitle
            ));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new UpdateNoteCommand
                {
                    Id = Guid.NewGuid(),
                    UserId = PickItEasyContextFactory.UserAId
                }, CancellationToken.None));
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateNoteCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new UpdateNoteCommand
                {
                    Id = PickItEasyContextFactory.NoteIdForUpdate,
                    UserId = PickItEasyContextFactory.UserAId
                }, CancellationToken.None));
        }
    }
}
