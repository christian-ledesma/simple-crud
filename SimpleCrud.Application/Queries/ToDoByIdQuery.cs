using MediatR;
using SimpleCrud.Entities.Entities;

namespace SimpleCrud.Application.Queries
{
    public class ToDoByIdQuery : IRequest<ToDo>
    {
        public int Id { get; set; }

        public ToDoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
