using Microsoft.EntityFrameworkCore;
using TodoDAL.Entities;

namespace TodoDAL
{
    public class TodoContext : ApplicationDbContext
    {
        public TodoContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}