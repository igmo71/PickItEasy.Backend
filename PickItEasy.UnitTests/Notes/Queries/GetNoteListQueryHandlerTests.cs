using AutoMapper;
using PickItEasy.Application.Notes.Queries.Notes.GetNoteList;
using PickItEasy.Persistence;
using PickItEasy.UnitTests.Common;
using Shouldly;

namespace PickItEasy.UnitTests.Notes.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListQueryHandlerTests
    {
        private readonly PickItEasyDbContext Context;
        private readonly IMapper Mapper;

        public GetNoteListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetNoteListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(new GetNoteListQuery
            {
                UserId = PickItEasyContextFactory.UserBId
            }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<NoteListVm>();
            result.Notes.Count.ShouldBe(2);
        }
    }
}
