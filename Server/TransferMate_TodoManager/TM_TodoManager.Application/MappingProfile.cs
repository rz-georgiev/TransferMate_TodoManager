using AutoMapper;
using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Core.Entities;

namespace TM_TodoManager.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserTask, NewTaskDto>();
            CreateMap<NewTaskDto, UserTask>();

            CreateMap<UserTask, UpdateTaskDto>();
            CreateMap<UpdateTaskDto, UserTask>();
            
            CreateMap<UserTask, ReadTaskDto>();
            CreateMap<ReadTaskDto, UserTask>();

        }
    }
}