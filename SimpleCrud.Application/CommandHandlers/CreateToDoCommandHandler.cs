using MediatR;
using SimpleCrud.Application.Commands;
using SimpleCrud.Domain.Repositories;
using SimpleCrud.Entities.Entities;

namespace SimpleCrud.Application.CommandHandlers
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand>
    {
        private readonly IToDoRepository _repository;

        public CreateToDoCommandHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = new ToDo
            {
                Name = request.Name,
                CreatedDate = request.CreatedDate,
            };
            await _repository.Create(todo);
        }
    }
}
