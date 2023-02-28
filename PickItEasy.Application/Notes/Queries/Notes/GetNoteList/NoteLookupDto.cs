using AutoMapper;
using PickItEasy.Application.Common.Mappings;
using PickItEasy.Application.Notes.Queries.Notes.GetNoteDetails;
using PickItEasy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Notes.Queries.Notes.GetNoteList
{
    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteVm => noteVm.Id, opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Title, opt => opt.MapFrom(note => note.Title));
        }
    }
}
