using CityInfo.API.Models;
using FluentValidation;

namespace CityInfo.API.Validators
{
    public class PointOfInterestUpdatevalidator : AbstractValidator<PointOfInterestUpdateDto>
    {
        public PointOfInterestUpdatevalidator()
        {

            RuleFor(poi=> poi.Name).NotNull().NotEmpty().MaximumLength(10).MinimumLength(3);
            When(c => c.Description != null, () =>
            {
                RuleFor(poi => poi.Description).MaximumLength(10).MinimumLength(3);
            });
        }
    }
}
