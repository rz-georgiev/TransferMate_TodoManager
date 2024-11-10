using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TM_TodoManager.Application.DTOs;
using TM_TodoManager.Infrastructure;
using TM_TodoManager.Shared.Models;

namespace TM_TodoManager.Application.Interfaces
{
    public class StatusService : IStatusService
    {
        private readonly TransferMateDbContext _dbContext;
        private readonly IMapper _mapper;

        public StatusService(TransferMateDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public async Task<BaseResponse<IEnumerable<ReadStatusDto>>> GetAll()
        {
            var statuses = await _dbContext.Statuses.ToListAsync();
            var result = _mapper.Map<IEnumerable<ReadStatusDto>>(statuses);

            return new BaseResponse<IEnumerable<ReadStatusDto>>
            {
                Result = result
            };
        }
    }
}