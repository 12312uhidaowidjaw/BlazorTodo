using Core.Dto;

namespace Core.Interface.Service
{
    public interface ITodoService
    {
        public Task Create(TodoDto newItemDto);

        public Task<IEnumerable<TodoDto>> GetAll();

        public Task Update(TodoDto itemDto);

        public Task Delete(string id);
    }
}