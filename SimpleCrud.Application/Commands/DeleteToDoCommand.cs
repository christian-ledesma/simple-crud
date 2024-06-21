using MediatR;

namespace SimpleCrud.Application.Commands
{
    public class DeleteToDoCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteToDoCommand(int id)
        {
            Id = id;
        }
    }
}
