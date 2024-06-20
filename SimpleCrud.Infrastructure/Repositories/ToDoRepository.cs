using Microsoft.EntityFrameworkCore;
using SimpleCrud.Domain.Repositories;
using SimpleCrud.Entities.Entities;
using SimpleCrud.Infrastructure.Data;

namespace SimpleCrud.Infrastructure.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly Context _context;

        public ToDoRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(ToDo entity)
        {
            _context.ToDos.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.ToDos.FindAsync(id);
            _context.ToDos.Remove(entity!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ToDo>> GetAll()
        {
            var result = await _context.ToDos.ToListAsync();
            return result;
        }

        public async Task<ToDo> GetById(int id)
        {
            var result = await _context.ToDos.FindAsync(id);
            return result!;
        }

        public async Task Update(ToDo entity)
        {
            _context.ToDos.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
