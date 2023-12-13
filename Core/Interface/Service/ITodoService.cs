using Core.Dto;

namespace Core.Interface.Service
{
    public interface ITodoService
    {
        public Task<TodoDto> Create(TodoDto newItemDto);

        public Task<IEnumerable<TodoDto>> GetAll();

        public Task<TodoDto> Update(TodoDto itemDto);

        public Task Delete(string id);
    }
}