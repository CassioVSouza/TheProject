using MediatR;
using The_Project.Domain.Entities;
using The_Project.Infrastructure.Persistence.Data;

namespace The_Project.Application.Features.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
    {

        private readonly AppDbContext _dbContext;
        public CreateScheduleCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new ScheduleEntity()
            {
                Name = request.name,
                Description = request.description,
                DateBegin = request.beginData,
                DateEnd = request.endData,
            };

            _dbContext.Schedule.Add(schedule);
            await _dbContext.SaveChangesAsync();

            if (schedule.Id == 0)
                return 0;

            return schedule.Id;
        }
    }
}
