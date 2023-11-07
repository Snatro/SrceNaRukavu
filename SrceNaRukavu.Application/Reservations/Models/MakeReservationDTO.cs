using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Reservations.Models
{
    public class MakeReservationDTO
    {
        public Person Person { get; set; }
        public Product Product { get; set; }
    }
}
