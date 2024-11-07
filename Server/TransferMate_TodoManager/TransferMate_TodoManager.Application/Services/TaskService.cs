using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

            await _dbContext.UserTasks.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse { IsOk = true };
        }

        public async Task<BaseResponse> UpdateTaskAsync(UpdateTaskDto dto)
        {
            var task = await _dbContext.UserTasks.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (task == null)
                return new BaseResponse { IsOk = false, Message = "A task with the provided id does not exist" };

            var updatedTask = _mapper.Map<Task>(dto);

            _dbContext.UserTasks.Update(task);
            await _dbContext.SaveChangesAsync();

            return new BaseResponse { IsOk = true };
        }

        public async Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetPendingTasksAsync()
        {
            var tasks = _dbContext.UserTasks.Where(x => x.DueDate < DateTime.UtcNow && x.StatusId != (int)StatusType.Done);
            return await GetTasksSummaryAsync(tasks);
        }

        public async Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetOverdueTasksAsync()
        {
            var tasks = _dbContext.UserTasks.Where(x => x.DueDate >= DateTime.UtcNow && x.StatusId != (int)StatusType.Done);
            return await GetTasksSummaryAsync(tasks);
        }

        private async Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetTasksSummaryAsync(IQueryable<UserTask> tasks)
        {
            var result = await tasks.Select(x => new ReadTaskDto
            {
                Id = x.Id,
                Name = x.Name,
                DueDate = x.DueDate,
                StatusId = x.StatusId,
                StatusName = x.Status.Name
            })
            .ToListAsync();

            return new BaseResponse<IEnumerable<ReadTaskDto>>
            {
                IsOk = true,
                Result = result
            };
        }
    }
}