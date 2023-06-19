using FluentValidation;
using GymMembership.Models.Requests;

namespace GymMembership.Validators
{
    public class AddClientRequestValidator :
        AbstractValidator<AddClientRequest>
    {
        public AddClientRequestValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .NotNull();
            RuleFor(x => x.PhoneNumber).NotEmpty().Must(w => w.ToString().Length < 10)
                .WithMessage("Minimum of 10 digits");

            RuleFor(a => a.Age)
               .NotNull();
            RuleFor(a => a.Age)
                   .GreaterThan(13)
                .WithMessage("Minimum 13 years old");
               
        }

    }
    }

