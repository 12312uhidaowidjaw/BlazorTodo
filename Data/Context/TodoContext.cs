using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options) { }

        public DbSet<Todo> Todo { get; set; }
    }
}