﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Internal;
using MediatR;
using Notes.Application.Interfaces;
using Notes.Domain1;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;
        public CreateNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserId,
                Title = request.Title,
                NoteName = request.NoteName,
                Details = request.Details,
                NoteId = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };
            await _dbContext.Notes.AddAsync(note, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return note.NoteId;

        }
    }
}
