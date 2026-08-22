using MediatR;

namespace The_Project.Application.Features.Schedule.Commands.CreateSchedule
{
    public record CreateScheduleCommand(string name, string description, DateTime beginData, DateTime endData) : IRequest<int>;
}
