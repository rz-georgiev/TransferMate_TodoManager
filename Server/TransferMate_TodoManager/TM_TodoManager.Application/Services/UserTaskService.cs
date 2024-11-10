using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Core.Entities;
using TM_TodoManager.Core.Enums;
using TM_TodoManager.Infrastructure;
using TM_TodoManager.Shared.Models;

namespace TM_TodoManager.Application.Interfaces
{
    public class UserTaskService : IUserTaskService
    {
        private readonly TransferMateDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserTaskService(TransferMateDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BaseResponse<ReadTaskDto>> CreateTaskAsync(NewTaskDto dto)
        {
            var validatedName = ValidateName(dto);
            if (!validatedName.IsOk) return validatedName;

            var newTask = _mapper.Map<UserTask>(dto);
            
            newTask.CreatedDateTime = DateTime.UtcNow;
            newTask.StatusId = (int)StatusType.ToDo;

            await _dbContext.UserTasks.AddAsync(newTask);
            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<ReadTaskDto>(newTask);
            result.StatusName = StatusType.ToDo.ToString();

            return new BaseResponse<ReadTaskDto> { IsOk = true, Result = result };
        }
        
        public async Task<BaseResponse<ReadTaskDto>> UpdateTaskAsync(UpdateTaskDto dto)
        {
            var validatedName = ValidateName(dto);
            if (!validatedName.IsOk) return validatedName;

            var possibleStatuses = Enum.GetValues(typeof(StatusType)).Cast<int>();
            if (!possibleStatuses.Contains(dto.StatusId))
                return new BaseResponse<ReadTaskDto> { IsOk = false, Message = "Specified status id is not valid, please choose 1 for ToDo, 2 for InProgress and 3 for Done" };

            var task = await _dbContext.UserTasks.SingleOrDefaultAsync(x => x.Id == dto.Id);
            if (task == null)
                return new BaseResponse<ReadTaskDto> { IsOk = false, Message = "A task with the provided id does not exist" };

            task.Name = dto.Name;
            task.DueDate = dto.DueDate;
            task.StatusId = dto.StatusId;
                   
            _dbContext.UserTasks.Update(task);
            await _dbContext.SaveChangesAsync();

            var result = _mapper.Map<ReadTaskDto>(task);
            result.StatusName = Enum.GetName(typeof(StatusType), task.StatusId) ?? string.Empty;

            return new BaseResponse<ReadTaskDto> { IsOk = true, Result = result };
        }

        public async Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetPendingTasksAsync()
        {
            var tasks = _dbContext.UserTasks.Where(x => x.DueDate < x.CreatedDateTime && x.StatusId != (int)StatusType.Done);
            return await GetTasksSummaryAsync(tasks);
        }

        public async Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetOverdueTasksAsync()
        {
            var tasks = _dbContext.UserTasks.Where(x => x.DueDate >= x.CreatedDateTime && x.StatusId != (int)StatusType.Done);
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
                StatusName = x.Status!.Name
            })
            .ToListAsync();

            return new BaseResponse<IEnumerable<ReadTaskDto>>
            {
                IsOk = true,
                Result = result
            };
        }

        private BaseResponse<ReadTaskDto> ValidateName(BaseTaskDto baseTask)
        {
            if (baseTask.Name == null || baseTask.Name.Length < 1 || baseTask.Name.Length > 50)
                return new BaseResponse<ReadTaskDto>
                {
                    IsOk = false,
                    Message = "Specified name should be between 1 and 50 chars long"
                };

            return new BaseResponse<ReadTaskDto>();
        }
    }
}