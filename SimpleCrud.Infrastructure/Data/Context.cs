using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleCrud.Domain.Entities;
using SimpleCrud.Entities.Entities;

namespace SimpleCrud.Infrastructure.Data
{
    public class Context : IdentityDbContext<User>
    {
        public Context(DbContextOptions options) : base(options)
        {
            
        }
        public virtual DbSet<ToDo> ToDos { get; set; }
    }
}
