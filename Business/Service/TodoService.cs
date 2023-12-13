using AutoMapper;
using Core.Dto;
using Core.Interface.Repository;
using Core.Interface.Service;
using Core.Model;
using System.Globalization;

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

        public async Task<TodoDto> Create(TodoDto newItemDto)
        {
            var newId = Guid.NewGuid().ToString();
            newItemDto.Id = newId;

            if(newItemDto.FormattedDate is not null)
            {
                if (DateTime.TryParseExact(newItemDto.FormattedDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dueDate))
                {
                    dueDate = DateTime.SpecifyKind(dueDate, DateTimeKind.Utc);
                    newItemDto.DueDate = dueDate;
                }
                else
                {
                    throw new ArgumentException("Invalid date format");
                }
            }

            var newItem = _mapper.Map<Todo>(newItemDto);

            await _repo.Create(newItem);

            return newItemDto;
        }

        public async Task<IEnumerable<TodoDto>> GetAll()
        {
            var list = await _repo.GetAll();

            var listDto = _mapper.Map<IEnumerable<TodoDto>>(list);

            foreach (var t in listDto)
            {
                t.FormattedDate = t.DueDate?.ToString("dd/MM/yyyy");
            }

            return listDto;
        }

        public async Task<TodoDto> Update(TodoDto itemDto)
        {
            var item = _mapper.Map<Todo>(itemDto);

            await _repo.Update(item);

            return itemDto;
        }

        public async Task Delete(string id)
        {
            await _repo.Delete(id);
        }
    }
}