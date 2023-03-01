using FluentValidation;

namespace PickItEasy.Application.Notes.Queries.Notes.GetNoteList
{
    public class GetNoteListQueryValidator : AbstractValidator<GetNoteListQuery>
    {
        public GetNoteListQueryValidator()
        {
            RuleFor(getNoteListQuery => getNoteListQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
