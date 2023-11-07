using Microsoft.EntityFrameworkCore;
using SrceNaRukavu.Application.Categories.Models;
using SrceNaRukavu.Application.Persistence;
using SrceNaRukavu.Application.Products.Models;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly SrceNaRukavuDbContext dbContext;

        public CategoryService(SrceNaRukavuDbContext context)
        {
            this.dbContext = context;
        }
        public async Task<int> CreateCategory(CreateCategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(categoryDTO, nameof(categoryDTO));

            Category category = new Category()
            {
                Name = categoryDTO.Name,
                Code = categoryDTO.Code
            };
            dbContext.Add(category);
            await dbContext.SaveChangesAsync();
            return category.Id;
        }

        public async Task<bool> DeleteCategory(int id, CancellationToken cancellationToken)
        {
            Category category = await dbContext.Categories.Where(category => category.Id == id).FirstOrDefaultAsync();
            if(category == null)
            {
                return false;
            }
            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IReadOnlyList<CategoryDTO>> GetAllCategories(CancellationToken cancellationToken)
        {
            return await dbContext.Categories.AsNoTracking()
                .Select(category => new CategoryDTO {
                    Id = category.Id,
                    Name = category.Name,
                    Code = category.Code
                }
                ).ToListAsync(cancellationToken);
        }

        public async Task<CategoryDTO> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            return await dbContext.Categories.Where(category => category.Id == id)
               .Select(category => new CategoryDTO
               {
                   Id = category.Id,
                   Name = category.Name,
                   Code = category.Code
               }
               ).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
