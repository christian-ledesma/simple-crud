using SimpleCrud.Entities.Entities;

namespace SimpleCrud.Domain.Repositories
{
    public interface IToDoRepository
    {
        Task<List<ToDo>> GetAll();
        Task<ToDo> GetById(int id);
        Task Create(ToDo entity);
        Task Update(ToDo entity);
        Task Delete(int id);
    }
}
