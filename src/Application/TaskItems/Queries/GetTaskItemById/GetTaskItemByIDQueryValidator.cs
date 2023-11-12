namespace Microsoft.Extensions.DependencyInjection.TaskItems.Queries;

public class GetTaskItemByIdQueryValidator : AbstractValidator<GetTaskItemByIdQuery>
{
    public GetTaskItemByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
    }
}
