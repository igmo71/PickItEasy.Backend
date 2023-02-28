using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Notes.Queries.Notes.GetNoteList
{
    public class NoteListVm
    {
        public IList<NoteLookupDto>? Notes { get; set; }
    }
}
