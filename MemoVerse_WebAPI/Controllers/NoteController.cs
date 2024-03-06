using MediatR;
using MemoVerse_Commends.Commend.NoteCommends.Commend;
using MemoVerse_Commends.Commend.NoteCommends.Query;
using MemoVerse_DTO.Note;
using Microsoft.AspNetCore.Mvc;

namespace MemoVerse_WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly IMediator mediator;
    public NoteController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> AddNote(NoteFromDto formDto)
    {
        var result = await mediator.Send(new AddNote(formDto));
        return Ok(result);
    }
    [HttpPut]
    [Route("[action]")]
    public async Task<IActionResult> UpdateNote(NoteUpdateFromDto formDto)
    {
        await mediator.Send(new UpdateNote(formDto));
        return Ok();
    }
    [HttpDelete]
    [Route("[action]")]
    public async Task<IActionResult> RemoveNote(Guid Id)
    {
        await mediator.Send(new RemoveNote(Id));
        return Ok();
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetAllNotes()
    {
        var result = await mediator.Send(new GetAllNotes());

        return Ok(result);
    }
    [HttpGet]
    [Route("[action]")]
    public async Task<IActionResult> GetNote(Guid Id)
    {
        var result = await mediator.Send(new GetNote(Id));
        return Ok(result);
    }
}
