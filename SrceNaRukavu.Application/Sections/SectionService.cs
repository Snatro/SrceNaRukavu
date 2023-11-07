using Microsoft.EntityFrameworkCore;
using SrceNaRukavu.Application.Persistence;
using SrceNaRukavu.Application.Sections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Sections
{
    public class SectionService : ISectionService
    {
        private readonly SrceNaRukavuDbContext _context;

        public SectionService(SrceNaRukavuDbContext context)
        {
            _context = context;
        }

        public async Task<SectionDTO> GetSectionById(int id, CancellationToken cancellationToken)
        {
            return await _context.Sections.Where(section => section.Id == id)
                .Select(section => new SectionDTO
                {
                    Id = section.Id,
                    Name = section.Name
                }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<SectionDTO>> GetSections(CancellationToken cancellationToken)
        {
            return await _context.Sections.AsNoTracking()
               .Select(section => new SectionDTO
               {
                   Id = section.Id,
                   Name = section.Name
               }).ToListAsync(cancellationToken);
        }
    }
}
