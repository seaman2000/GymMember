using FluentValidation;
using GymMembership.Models.Models;

namespace GymMembership.Validators
{
   
    public class AddMembershipValidator : AbstractValidator<Membership>
    {
        public AddMembershipValidator()
        {
            RuleFor(x => x.Price)
                .NotEmpty();
            RuleFor(x => x.Price).NotEmpty().Must(w => w.ToString().Length < 3)
                .WithMessage("Maximum sum is to the hundreds");
        }

    }
}

