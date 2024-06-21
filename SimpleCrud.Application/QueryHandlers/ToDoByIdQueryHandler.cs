using MediatR;
using SimpleCrud.Application.Queries;
using SimpleCrud.Domain.Repositories;
using SimpleCrud.Entities.Entities;

namespace SimpleCrud.Application.QueryHandlers
{
    public class ToDoByIdQueryHandler : IRequestHandler<ToDoByIdQuery, ToDo>
    {
        private readonly IToDoRepository _repository;

        public ToDoByIdQueryHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ToDo> Handle(ToDoByIdQuery request, CancellationToken cancellationToken)
        {
            var todo = await _repository.GetById(request.Id);
            return todo;
        }
    }
}
