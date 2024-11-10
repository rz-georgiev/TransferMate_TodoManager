using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Shared.Models;

namespace TM_TodoManager.Application.Interfaces
{
    public interface IUserTaskService
    {
        /// <summary>
        /// Used to create a new user task
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResponse<ReadTaskDto>> CreateTaskAsync(NewTaskDto dto);

        /// <summary>
        /// Used to modify user task
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<BaseResponse<ReadTaskDto>> UpdateTaskAsync(UpdateTaskDto dto);

        /// <summary>
        /// Returns all pendings tasks which due date is before the creation date of the task
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetPendingTasksAsync();

        /// <summary>
        /// Returns all due tasks which due date is after the creation date of the task
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<IEnumerable<ReadTaskDto>>> GetOverdueTasksAsync();
    }
}