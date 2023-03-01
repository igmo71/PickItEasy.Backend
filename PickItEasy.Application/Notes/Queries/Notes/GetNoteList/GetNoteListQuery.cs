using MediatR;

namespace PickItEasy.Application.Notes.Queries.Notes.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}
