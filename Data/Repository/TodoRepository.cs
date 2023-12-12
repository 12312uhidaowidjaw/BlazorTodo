using Core.Interface.Repository;
using Core.Model;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }

        public async Task Create(Todo newItem)
        {
            await _context.AddAsync(newItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _context.Todo.ToListAsync();
        }

        public async Task Update(Todo item)
        {
            var todo = await _context.Todo.FindAsync(item.Id) ?? 
                throw new Exception("The item doesn't exist.");
            
            todo.Title = item.Title;
            todo.DueDate = item.DueDate;
            todo.Finished = item.Finished;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(string id)
        {
            var todo = await _context.Todo.FindAsync(id) ??
                throw new Exception("The item doesn't exist.");

            _context.Remove(todo);
            await _context.SaveChangesAsync();
        }
    }
}