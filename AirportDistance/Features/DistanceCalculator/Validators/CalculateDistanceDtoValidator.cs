using AirportDistance.Features.DistanceCalculator.Dtos;
using FluentValidation;

namespace AirportDistance.Features.DistanceCalculator.Validators
{
    public class CalculateDistanceDtoValidator: AbstractValidator<CalculateDistanceDto>
    {
        private const string IataRegex = "^[A-Z]{3}$";
        private const string IataErrorMessage = "Please provide valid IATA code. IATA codes consist of 3 uppercase latin letters.";

        public CalculateDistanceDtoValidator()
        {
            RuleFor(it => it.From)
                .NotEmpty();

            RuleFor(it => it.To)
                .NotEmpty();

            RuleFor(it => it.From)
                .Matches(IataRegex)
                .WithMessage(IataErrorMessage);
            
            RuleFor(it => it.To)
                .Matches(IataRegex)
                .WithMessage(IataErrorMessage);
        }
    }
}
