using MediatR;
using SimpleCrud.Application.Queries;
using SimpleCrud.Domain.Repositories;
using SimpleCrud.Entities.Entities;

namespace SimpleCrud.Application.QueryHandlers
{
    public class ToDoListQueryHandler : IRequestHandler<ToDoListQuery, IEnumerable<ToDo>>
    {
        private readonly IToDoRepository _repository;

        public ToDoListQueryHandler(IToDoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ToDo>> Handle(ToDoListQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAll();
            return result;
        }
    }
}
