using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleCrud.Application.Commands;
using SimpleCrud.Application.Queries;

namespace SimpleCrud.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly ISender _sender;

        public ToDosController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var response = await _sender.Send(new ToDoListQuery());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _sender.Send(new ToDoByIdQuery(id));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoCommand command)
        {
            await _sender.Send(command);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateToDoCommand command)
        {
            await _sender.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _sender.Send(new DeleteToDoCommand(id));
            return Ok();
        }
    }
}
