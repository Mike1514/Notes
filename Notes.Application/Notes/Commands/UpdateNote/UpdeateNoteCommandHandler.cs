using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Interfaces;
using Notes.Domain1;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdeateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, Unit>
    {
        private readonly INotesDbContext _dbContext;
        public UpdeateNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FirstOrDefaultAsync(note => 
                note.NoteId == request.NoteId, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.NoteId);
            }

            entity.NoteId = request.NoteId;
            entity.UserId = request.UserId;
            entity.NoteName = request.NoteName;
            entity.Title = request.Title;
            entity.Details = request.Details;


            return Unit.Value;
        }

    }
}
