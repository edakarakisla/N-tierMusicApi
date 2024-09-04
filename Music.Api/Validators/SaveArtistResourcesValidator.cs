using FluentValidation;
using Music.Api.DTO;

namespace Music.Api.Validators
{
    public class SaveArtistResourcesValidator : AbstractValidator<SaveArtistDTO>
    {
        public SaveArtistResourcesValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        }
    }
}

   
