using System;
using FluentValidation;


namespace Client
{
    public class ValidateCreateVisitorRequest : AbstractValidator<Models.CreateVisitorRequest>
    {
       
        public ValidateCreateVisitorRequest()
        {
            RuleFor(x => x.Name).
                Cascade(CascadeMode.Stop).NotEmpty().WithMessage("No Name was entered").
                MaximumLength(30).WithMessage("Name is too long").
                MinimumLength(2).WithMessage("Name is too short");
             
            RuleFor(x => x.Age).
                Cascade(CascadeMode.Stop).NotEmpty().WithMessage("No Age was entered").
                Must(x => x < 110).WithMessage("This visitor is too old").
                Must(x => x > 18).WithMessage("This visitor is too young");
        }
    }
}
