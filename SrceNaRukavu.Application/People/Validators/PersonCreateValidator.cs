using FluentValidation;
using SrceNaRukavu.Application.People.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.People.Validators
{
    public class PersonCreateValidator: AbstractValidator<CreatePersonDTO>
    {
        public PersonCreateValidator() { }
    }
}
