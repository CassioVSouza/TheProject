using MediatR;
using The_Project.Domain.Entities;

namespace The_Project.Application.Features.Schedule.Queries
{
    public record GetScheduleQuery(int? id, string? name, string? description, DateTime? beginData, DateTime? endData) : IRequest<List<ScheduleEntity>>;
}
