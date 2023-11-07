using SrceNaRukavu.Application.Reservations.Models;
using SrceNaRukavu.Application.Roles.Models;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Reservations
{
    public interface IReservationService
    {
        public Task<IReadOnlyList<ReservationDTO>> GetReservations(CancellationToken cancellationToken);
        public Task<ReservationDTO> GetReservationById(int id, CancellationToken cancellationToken);
        public Task<IReadOnlyList<ReservationDTO>> GetReservationsByPersonId(int personId, CancellationToken cancellationToken);
        public Task<bool> RemoveReservation(int id, CancellationToken token);
        public Task<int> CreateReservation(MakeReservationDTO model,  CancellationToken cancellationToken); 
    }
}
