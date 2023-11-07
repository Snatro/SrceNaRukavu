using SrceNaRukavu.Application.Categories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Categories
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken);
        Task<CategoryDTO> GetCategoryById(int id, CancellationToken cancellationToken);
        Task<int> CreateCategory(CreateCategoryDTO categoryDTO, CancellationToken cancellationToken);
        Task<bool> DeleteCategory(int id, CancellationToken cancellationToken);
    }
}
