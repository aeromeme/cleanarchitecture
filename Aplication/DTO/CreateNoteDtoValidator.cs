using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Aplication.DTO
{
    public class CreateNoteDtoValidator : AbstractValidator<CreateNoteDto>
    {
        public CreateNoteDtoValidator()
        {
            RuleFor(x => x.ItemId).GreaterThan(0);
            RuleFor(x => x.Message).NotEmpty().MaximumLength(250);
        }
    }
}
