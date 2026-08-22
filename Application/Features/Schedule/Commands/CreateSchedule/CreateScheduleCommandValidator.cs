using FluentValidation;

namespace The_Project.Application.Features.Schedule.Commands.CreateSchedule
{
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Field cannot be empty")
                .NotNull().WithMessage("Field cannot be empty")
                .MaximumLength(100).WithMessage("Field reached maximum characters (100)")
                .MinimumLength(5).WithMessage("Field reached minimum characters (5)");

            RuleFor(x => x.description)
                .NotEmpty().WithMessage("Field cannot be empty")
                .NotNull().WithMessage("Field cannot be empty")
                .MaximumLength(300).WithMessage("Field reached maximum characters (300)")
                .MinimumLength(5).WithMessage("Field reached minimum characters (5)");
        }
    }
}
