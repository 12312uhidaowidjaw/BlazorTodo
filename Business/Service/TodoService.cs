using AutoMapper;
using Core.Dto;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Model;

namespace Business.Service
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _repo;
        private readonly IMapper _mapper;

        public TodoService(ITodoRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task Create(TodoDto newItemDto)
        {
            var newItem =  _mapper.Map<Todo>(newItemDto);
            var newId = Guid.NewGuid().ToString();
            newItem.Id = newId;

            await _repo.Create(newItem);
        }

        public async Task<IEnumerable<TodoDto>> GetAll()
        {
            var list = await _repo.GetAll();

            var listDto = _mapper.Map<IEnumerable<TodoDto>>(list);

            return listDto;
        }

        public async Task Update(TodoDto itemDto)
        {
            var item = _mapper.Map<Todo>(itemDto);

            await _repo.Update(item);
        }

        public async Task Delete(string id)
        {
            await _repo.Delete(id);
        }
    }
}