using Bogus;
using SrceNaRukavu.Application.People.Models;
using SrceNaRukavu.Application.Products.Models;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Reservations.Models
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public PersonSimpleDTO Person { get; set; }
        public ProductSimpleDTO Product { get; set; }
        public static ReservationDTO FromModel(Reservation model)
        {
            return new ReservationDTO
            {
                Id = model.Id,
                Person = PersonSimpleDTO.FromModel(model.Person),
                Product = ProductSimpleDTO.FromModel(model.Product)
            };
        }

    }
}
