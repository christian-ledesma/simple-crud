using MediatR;

namespace SimpleCrud.Application.Commands
{
    public class CreateToDoCommand : IRequest
    {
        public required string Name { get; set; }
        public required string CreatedDate { get; set; }
    }
}
