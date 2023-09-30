using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
    {
        public UpdateNoteCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.UserId).NotEqual(Guid.Empty).NotEmpty();
            RuleFor(updateNoteCommand => updateNoteCommand.NoteId).NotEqual(Guid.Empty).NotEmpty();
            RuleFor(updateNoteCommand => updateNoteCommand.Title).MaximumLength(250).NotEmpty();
            RuleFor(updateNoteCommand => updateNoteCommand.Details).MaximumLength(500).NotEmpty();
            RuleFor(updateNoteCommand => updateNoteCommand.NoteName).MaximumLength(100).NotEmpty();
        }
    }
}
