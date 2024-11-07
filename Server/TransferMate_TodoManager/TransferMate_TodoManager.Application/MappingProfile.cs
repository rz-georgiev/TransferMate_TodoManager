using AutoMapper;
using TM_TodoManager.Application.DTOs;

namespace TM_TodoManager.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Task, NewTaskDto>();
            CreateMap<NewTaskDto, Task>();

        }
    }
}