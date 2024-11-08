using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Shared.Models;

namespace TM_TodoManager.Application.Interfaces
{
    public interface IStatusService
    {
        Task<BaseResponse<IEnumerable<ReadStatusDto>>> GetAll();

    }
}