﻿using AutoMapper;
using PickItEasy.Application.Common.Mappings;
using PickItEasy.Application.Notes.Commands.CreateNote;
using System.ComponentModel.DataAnnotations;

namespace PickItEasy.WebApi.Models
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        [Required]
        public string Title { get; set; } = null!;

        public string? Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Title, opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details, opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
