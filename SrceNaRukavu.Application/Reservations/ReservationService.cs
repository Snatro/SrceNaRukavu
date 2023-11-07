using Microsoft.EntityFrameworkCore;
using SrceNaRukavu.Application.People.Models;
using SrceNaRukavu.Application.Persistence;
using SrceNaRukavu.Application.Products.Models;
using SrceNaRukavu.Application.Reservations.Models;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Reservations
{
    public class ReservationService : IReservationService
    {
        private readonly SrceNaRukavuDbContext _dbContext;
        public ReservationService(SrceNaRukavuDbContext dbContext) { 
            _dbContext = dbContext;
        }
        public async Task<int> CreateReservation(MakeReservationDTO model, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(model, nameof(model));
            Reservation reservation = new Reservation()
            {
                PersonId = model.Person.Id,
                ProductId = model.Product.Id,
            };
            _dbContext.Add(reservation);
            await _dbContext.SaveChangesAsync();
            return reservation.PersonId;
        }

        public async Task<ReservationDTO> GetReservationById(int id, CancellationToken cancellationToken)
        {
            return await _dbContext.Reservations.Where(reservation => reservation.Id == id).Include(reservation => reservation.Person).Include(reservation => reservation.Product)
                .Select(reservation => ReservationDTO.FromModel(reservation)).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<ReservationDTO>> GetReservations(CancellationToken cancellationToken)
        {
           return await _dbContext.Reservations.AsNoTracking()
                .Include(reservation => reservation.Person)
                .Include(reservation => reservation.Product)
                .Select(reservation => ReservationDTO.FromModel(reservation))
                 .ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<ReservationDTO>> GetReservationsByPersonId(int personId, CancellationToken cancellationToken)
        {
            return await _dbContext.Reservations.AsNoTracking().Where(reservation => reservation.PersonId == personId)
                .Include(reservation => reservation.Person)
                .Include(reservation => reservation.Product)
                .Select(reservation => ReservationDTO.FromModel(reservation))
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> RemoveReservation(int id, CancellationToken token)
        {
            Reservation reservation = await _dbContext.Reservations.Where(reservation => reservation.Id == id).FirstOrDefaultAsync();
            
            if(reservation == null)
            {
                return false;
            }

            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync(token);
            return true;
        }
    }
}
