using FluentValidation;

namespace The_Project.Application.Features.Schedule.Queries
{
    public class GetScheduleQueryValidator : AbstractValidator<GetScheduleQuery>
    {
        public GetScheduleQueryValidator()
        {
            RuleFor(o => o.name)
                .MaximumLength(100).WithMessage("Field reached maximum characters (100)");

            RuleFor(o => o.description)
                .MaximumLength(400).WithMessage("Field reached maximum characters (400)");
        }
    }
}
