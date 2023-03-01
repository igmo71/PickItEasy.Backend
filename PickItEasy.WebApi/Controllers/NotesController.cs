using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PickItEasy.Application.Notes.Commands.CreateNote;
using PickItEasy.Application.Notes.Commands.DeleteNote;
using PickItEasy.Application.Notes.Commands.UpdateNote;
using PickItEasy.Application.Notes.Queries.Notes.GetNoteDetails;
using PickItEasy.Application.Notes.Queries.Notes.GetNoteList;
using PickItEasy.WebApi.Models;

namespace PickItEasy.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : BaseController
    {
        private readonly IMapper _mapper;

        public NotesController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var getNoteListQuery = new GetNoteListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(getNoteListQuery);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
        {
            var getNoteDetailsQuery = new GetNoteDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(getNoteDetailsQuery);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteDto crateNoteDto)
        {
            var createNoteCommand = _mapper.Map<CreateNoteCommand>(crateNoteDto);
            createNoteCommand.UserId = UserId;
            var id = await Mediator.Send(createNoteCommand);
            return Ok(id);
            //return CreatedAtAction(nameof(Get), new { id }, crateNoteDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateNoteDto updateNoteDto)
        {
            var updateNoteCommand = _mapper.Map<UpdateNoteCommand>(updateNoteDto);
            updateNoteCommand.UserId = UserId;
            await Mediator.Send(updateNoteCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteNoteCommand = new DeleteNoteCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(deleteNoteCommand);
            return NoContent();
        }
    }
}
