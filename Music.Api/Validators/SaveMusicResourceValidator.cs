using FluentValidation;
using Music.Api.DTO;

namespace Music.Api.Validators
{

    public class SaveMusicResourceValidator : AbstractValidator<SaveMusic>
    {
        public SaveMusicResourceValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.ArtistId).NotEmpty().WithMessage("Artist Id must not be empty");

        }
    }
}
