using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Notes.Queries.Notes.GetNoteList
{
    public class GetNoteListQuery : IRequest<NoteListVm>
    {
        public Guid UserId { get; set; }
    }
}
