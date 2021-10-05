namespace Wordsmith.Api.Validators
{
    using FluentValidation;
    using Wordsmith.Api.Models;

    public class WordReversalRequestValidator: AbstractValidator<WordReversalRequest>
    {
        public WordReversalRequestValidator()
        {
            RuleFor(x => x.Input).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}

