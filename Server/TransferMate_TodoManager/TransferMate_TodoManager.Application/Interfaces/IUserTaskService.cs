using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Shared.Models;

namespace TM_TodoManager.Application.Interfaces
{
    public interface IUserTaskService
    {
        Task<BaseResponse> CreateTaskAsync(NewTaskDto dto);

        Task<BaseResponse> UpdateTaskAsync(UpdateTaskDto dto);

        Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetPendingTasksAsync();

        Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetOverdueTasksAsync();
    }
}