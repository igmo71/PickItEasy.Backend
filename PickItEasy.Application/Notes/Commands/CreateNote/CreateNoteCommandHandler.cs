﻿using MediatR;
using PickItEasy.Application.Interfaces;
using PickItEasy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly IPickItEasyDbContext  _dbContext;

        public CreateNoteCommandHandler(IPickItEasyDbContext dbContext) => _dbContext = dbContext;

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return note.Id;
        }
    }
}
