using FluentValidation;

namespace WebApi.Artist.Request;

public class AddArtistRequestValidator: AbstractValidator<AddArtistRequest>
{
    public AddArtistRequestValidator()
    {
        RuleFor(x => x.Gender).NotNull();
        RuleFor(x => x.Name).Length(10, 20);
    }
}
