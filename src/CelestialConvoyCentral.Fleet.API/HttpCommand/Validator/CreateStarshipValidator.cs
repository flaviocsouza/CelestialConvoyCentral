using FluentValidation;

namespace CelestialConvoyCentral.Fleet.API;

public class CreateStarshipValidator : AbstractValidator<CreateStarshipCommand>
{
    CreateStarshipValidator()
    {
        RuleFor(x => x.ModelId)
            .GreaterThan(0);
    }

}
