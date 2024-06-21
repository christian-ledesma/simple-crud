using MediatR;

namespace SimpleCrud.Application.Commands
{
    public class UpdateToDoCommand : IRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string CreatedDate { get; set; }
    }
}
