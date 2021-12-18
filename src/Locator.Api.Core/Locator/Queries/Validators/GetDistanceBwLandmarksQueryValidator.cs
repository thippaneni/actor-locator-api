using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.Api.Core.Locator.Queries.Validators
{
    public class GetDistanceBwLandmarksQueryValidator : AbstractValidator<GetDistanceBwLandmarksQuery>
    {
        public GetDistanceBwLandmarksQueryValidator()
        {
            RuleFor(x => x.StartingLandMark.Code)
                    .NotNull()
                    .NotEmpty().WithMessage("StartingLandMark Code should not be null or empty");

            RuleFor(x => x.EndingLandMark.Code)
                    .NotNull()
                    .NotEmpty().WithMessage("EndingLandMark Code should not be null or empty");

            RuleFor(x => x.ViaLandMarks)
                    .NotNull()
                    .WithMessage("ViaLandMarks Codes should not be null");

            RuleFor(x => x.ViaLandMarks.Any())
                    .NotEqual(false)
                    .WithMessage("ViaLandMarks Codes should not be empty");

            RuleFor(x => x.StartingLandMark.Code.Equals(x.EndingLandMark.Code))
                    .NotEqual(true)
                    .WithMessage("Starting and Ending landmarks should be different");

            RuleFor(x => x.ViaLandMarks.Count() != x.ViaLandMarks.Distinct().Count())
                    .NotEqual(true)
                    .WithMessage("Starting and Ending landmarks should be different");
        }
    }
}
