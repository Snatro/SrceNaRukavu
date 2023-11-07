using SrceNaRukavu.Application.Sections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Sections
{
    public interface ISectionService
    {
        Task<IReadOnlyList<SectionDTO>> GetSections(CancellationToken cancellationToken);
        Task<SectionDTO> GetSectionById(int id, CancellationToken cancellationToken);
    }
}
