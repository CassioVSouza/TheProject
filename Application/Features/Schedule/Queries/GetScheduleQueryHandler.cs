using MediatR;
using Microsoft.EntityFrameworkCore;
using The_Project.Domain.Entities;
using The_Project.Infrastructure.Persistence.Data;

namespace The_Project.Application.Features.Schedule.Queries
{
    public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, List<ScheduleEntity>>
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<GetScheduleQueryHandler> _logger;

        public GetScheduleQueryHandler(AppDbContext dbContext, ILogger<GetScheduleQueryHandler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<List<ScheduleEntity>> Handle(GetScheduleQuery request, CancellationToken cancellation)
        {
            try
            {
                var query = _dbContext.Schedule.AsNoTracking().AsQueryable();

                if (!string.IsNullOrWhiteSpace(request.name))
                    query = query.Where(o => o.Name == request.name);

                if (!string.IsNullOrEmpty(request.description))
                    query = query.Where(o => o.Description == request.description);

                if (request.beginData != null)
                    query = query.Where(o => o.DateBegin < request.beginData);

                if (request.endData != null)
                    query = query.Where(o => o.DateEnd > request.endData);

                var result = await query
                    .Select(o => new ScheduleEntity { Id = o.Id, Name = o.Name, Description = o.Description, DateEnd = o.DateEnd, DateBegin = o.DateBegin })
                    .ToListAsync();

                return result;
            }
            catch (Exception ex) {
                _logger.LogError($"{DateTime.UtcNow} | Error in {nameof(Handle)} | {nameof(GetScheduleQueryHandler)} | {ex.Message}");
                return new List<ScheduleEntity>();
            }
        }
    }
}
