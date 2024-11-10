using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Shared.Models;

namespace TM_TodoManager.Application.Interfaces
{
    public interface IStatusService
    {
        /// <summary>
        /// Returns all types of tasks statuses
        /// </summary>
        /// <returns></returns>
        Task<BaseResponse<IEnumerable<ReadStatusDto>>> GetAll();

    }
}