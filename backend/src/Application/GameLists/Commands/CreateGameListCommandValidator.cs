using FluentValidation;

namespace GameApp.Application.GameLists.Commands;

public class CreateGameListCommandValidator : AbstractValidator<CreateGameListCommand>
{
    public CreateGameListCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();

        RuleFor(v => v.Description)
            .MaximumLength(500);
    }
}
