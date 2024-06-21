using MediatR;
using SimpleCrud.Application.Commands;
using SimpleCrud.Domain.Repositories;

namespace SimpleCrud.Application.CommandHandlers
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
    {
        private readonly IToDoRepository _repository;

        public DeleteToDoCommandHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            await _repository.Delete(request.Id);
        }
    }
}
