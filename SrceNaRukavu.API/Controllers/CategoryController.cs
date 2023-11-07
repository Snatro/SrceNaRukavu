using Microsoft.AspNetCore.Mvc;
using SrceNaRukavu.Application.Categories;
using SrceNaRukavu.Application.Categories.Models;

namespace SrceNaRukavu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet (Name = nameof(GetCategories))]
        public async Task<IReadOnlyList<CategoryDTO>> GetCategories(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAllCategories (cancellationToken);
        }

        [HttpGet ("{id}", Name = nameof(GetCategoryById))]
        public async Task<CategoryDTO> GetCategoryById([FromRoute] int id, CancellationToken cancellationToken)
        {
            return await _categoryService.GetCategoryById(id,cancellationToken);
        }

    }
}
