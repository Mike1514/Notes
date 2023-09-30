using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.WebAPI.Models;

namespace Notes.WebAPI.Controllers
{
//[Route("api/[controller]")]
   public class NoteController : BaseController
    {
        private readonly IMapper _mapper;
        public  NoteController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAllNotes()
        {
            var query = new GetNoteListQuery
            {
                UsertId = UserId

            };                
            var vm =  await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> GetNoteById(Guid id)
        {
            var query = new GetNoteDetailsQuery()
            {
                UserId = UserId,
                NoteId = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNote([FromBody] CreateNoteDto createNoteDto)
        {
            var command = _mapper.Map<CreateNoteCommand>(createNoteDto);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Created($"{noteId}", command);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateNote([FromBody] UpdateNoteDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Guid>> DeleteNote(Guid id)
        {
            var command = new DeleteNoteCommand
            {
                NoteId = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return Ok();

        }

    }
}
