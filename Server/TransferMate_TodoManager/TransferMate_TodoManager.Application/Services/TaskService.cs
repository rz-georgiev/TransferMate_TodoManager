using AutoMapper;
using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Core.Enums;
using TM_TodoManager.Domain.Entities;
using TM_TodoManager.Infrastructure;
using TM_TodoManager.Shared.Models.MotoDev.Common.Dtos;

namespace TM_TodoManager.Application.Interfaces
{
    public class TaskService : ITaskService
    {
        private readonly TransferMateDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskService(TransferMateDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse> CreateTaskAsync(NewTaskDto dto)
        {
            var newTask = _mapper.Map<UserTask>(dto);
            newTask.StatusId = (int)StatusType.ToDo;

            try
            {
                await _dbContext.Tasks.AddAsync(newTask);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    IsOk = true
                };
            }
            catch (Exception)
            {
                return new BaseResponse
                {
                    IsOk = false,
                    Message = "An error occurred while adding new task to the system";
                };
            }
        }

        public async Task<BaseResponse> UpdateTaskAsync(UpdateTaskDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ReadTaskDto>> GetOverdueTasksAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseResponse<ReadTaskDto>> GetPendingTasksAsync()
        {
            throw new NotImplementedException();
        }
    }
}