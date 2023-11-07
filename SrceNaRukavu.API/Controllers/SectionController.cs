using Microsoft.AspNetCore.Mvc;
using SrceNaRukavu.Application.Sections;
using SrceNaRukavu.Application.Sections.Models;

namespace SrceNaRukavu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SectionController : Controller
    {
        private readonly ISectionService _sectionService;
        public SectionController(ISectionService sectionService)
        {
            _sectionService = sectionService;
        }

        [HttpGet(Name = nameof(GetSections))]
        public async Task<IReadOnlyList<SectionDTO>> GetSections(CancellationToken token)
        {
            return await _sectionService.GetSections(token);    
        } 
        
        [HttpGet("{id}",Name = nameof(GetSectionById))]
        public async Task<IActionResult> GetSectionById([FromRoute] int id,CancellationToken token)
        {
            SectionDTO section = await _sectionService.GetSectionById(id,token);    
            return section != null ? Ok(section) : NotFound();
        }
    }
}
