using Microsoft.AspNetCore.Mvc;
using SrceNaRukavu.Application.Products.Models;
using SrceNaRukavu.Application.Products;
using SrceNaRukavu.Application.Reservations;
using SrceNaRukavu.Domain;
using SrceNaRukavu.Application.Reservations.Models;

namespace SrceNaRukavu.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        [HttpGet(Name = nameof(GetReservations))]
        public async Task<IReadOnlyList<ReservationDTO>> GetReservations(CancellationToken token)
        {
            return await reservationService.GetReservations(token);
        }
        
        [HttpGet("person/{id:int}/reservations")]
        public async Task<IReadOnlyList<ReservationDTO>> GetReservationsByPersonId([FromRoute] int id, CancellationToken token)
        {
            return await reservationService.GetReservationsByPersonId(id,token);
        }
        
        [HttpGet("{id}",Name = nameof(GetReservationById))]
        public async Task<ReservationDTO> GetReservationById([FromRoute] int id, CancellationToken token)
        {
            return await reservationService.GetReservationById(id,token);
        }

        [HttpPost(Name = nameof(MakeReservation))]
        public async Task<int> MakeReservation([FromBody] MakeReservationDTO model, CancellationToken cancellationToken)
        {
            return await reservationService.CreateReservation(model, cancellationToken);
        }

        [HttpDelete("{id}", Name = nameof(DeleteReservation))]
        public async Task<bool> DeleteReservation([FromRoute]int id, CancellationToken cancellationToken)
        {
            return await reservationService.RemoveReservation(id, cancellationToken);
        }
    }
}
