using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Shared.Models.MotoDev.Common.Dtos;

namespace TM_TodoManager.Application.Interfaces
{
    public interface ITaskService
    {
        Task<BaseResponse> CreateTaskAsync(NewTaskDto dto);

        Task<BaseResponse> UpdateTaskAsync(UpdateTaskDto dto);

        Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetPendingTasksAsync();

        Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetOverdueTasksAsync();
    }
}