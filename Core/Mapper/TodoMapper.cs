using AutoMapper;
using Core.Dto;
using Core.Model;

namespace Core.Mapper
{
    public class TodoMapper : Profile
    {
        public TodoMapper()
        {
            CreateMap<Todo, TodoDto>().ReverseMap();
        }
    }
}