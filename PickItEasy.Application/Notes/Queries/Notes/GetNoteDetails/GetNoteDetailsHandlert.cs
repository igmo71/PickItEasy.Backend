﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PickItEasy.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PickItEasy.Application.Common.Exceptions;
using PickItEasy.Domain;

namespace PickItEasy.Application.Notes.Queries.Notes.GetNoteDetails
{
    public class GetNoteDetailsHandlert : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
    {
        private readonly IPickItEasyDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNoteDetailsHandlert(IPickItEasyDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            return _mapper.Map<NoteDetailsVm>(entity);
        }
    }
}
