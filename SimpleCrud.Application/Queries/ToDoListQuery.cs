using MediatR;
using SimpleCrud.Entities.Entities;

namespace SimpleCrud.Application.Queries
{
    public class ToDoListQuery : IRequest<IEnumerable<ToDo>>
    {
    }
}
