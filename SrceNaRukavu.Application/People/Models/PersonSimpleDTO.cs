using Microsoft.Identity.Client;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.People.Models
{
    public class PersonSimpleDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? TelephoneNumber { get; set; }

        public static PersonSimpleDTO FromModel(Person model)
        {
            return new PersonSimpleDTO
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                TelephoneNumber = model.Telephone
            };
        }
    }
}
