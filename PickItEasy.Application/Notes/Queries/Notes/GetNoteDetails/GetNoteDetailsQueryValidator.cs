using FluentValidation;

namespace PickItEasy.Application.Notes.Queries.Notes.GetNoteDetails
{
    public class GetNoteDetailsQueryValidator : AbstractValidator<GetNoteDetailsQuery>
    {
        public GetNoteDetailsQueryValidator()
        {
            RuleFor(getNoteDetailsQuery => getNoteDetailsQuery.Id).NotEqual(Guid.Empty);
            RuleFor(getNoteDetailsQuery => getNoteDetailsQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}
