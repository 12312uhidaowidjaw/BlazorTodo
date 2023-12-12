using Core.Model;

namespace Core.Interface.Repository
{
    public interface ITodoRepository
    {
        public Task Create(Todo newItem);

        public Task<IEnumerable<Todo>> GetAll();

        public Task Update(Todo item);

        public Task Delete(string id);
    }
}