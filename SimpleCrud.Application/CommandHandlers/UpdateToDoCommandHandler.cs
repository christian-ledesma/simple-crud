using MediatR;
using SimpleCrud.Application.Commands;
using SimpleCrud.Domain.Repositories;

namespace SimpleCrud.Application.CommandHandlers
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand>
    {
        private readonly IToDoRepository _repository;

        public UpdateToDoCommandHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var todo = await _repository.GetById(request.Id);
            
            todo.Name = request.Name;
            todo.CreatedDate = request.CreatedDate;

            await _repository.Update(todo);
        }
    }
}
