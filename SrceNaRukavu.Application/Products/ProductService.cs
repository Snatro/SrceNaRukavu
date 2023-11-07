using Microsoft.EntityFrameworkCore;
using SrceNaRukavu.Application.People.Models;
using SrceNaRukavu.Application.Persistence;
using SrceNaRukavu.Application.Products.Models;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Products
{
    internal class ProductService : IProductService
    {
        private readonly SrceNaRukavuDbContext dbContext;

        public ProductService(SrceNaRukavuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CreateProduct(CreateProductDTO createProductDTO, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(createProductDTO, nameof(createProductDTO));

            Product product = new Product()
            {
                Name = createProductDTO.Name,
                CategoryId = createProductDTO.CategoryId,
                Description = createProductDTO.Description,
                Price = createProductDTO.Price,
                Size = createProductDTO.Size,
                SectionId = createProductDTO.SectionId,
                Image = createProductDTO.Image
            };
            dbContext.Add(product);
            await dbContext.SaveChangesAsync();
            return product.Id;
        }

        public async Task<bool> DeleteProduct(int id, CancellationToken cancellationToken)
        {
            Product product = await dbContext.Products.Where(product => product.Id == id).FirstOrDefaultAsync(cancellationToken);
            if (product == null)
            {
                return false;
            }
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<ProductDTO> GetProductById(int id, CancellationToken cancellationToken)
        {
            return await dbContext.Products.Where(product => product.Id == id)
                .Include(p => p.Reservation)
               .Select(product => new ProductDTO
               {
                   Id = product.Id,
                   Name = product.Name,
                   Category = product.Category,
                   Description = product.Description,
                   Price = product.Price,
                   Size = product.Size,
                   IsReserved = product.Reservation != null ? true: false,
                   Section = product.Section,
                   Image = product.Image,

               }).FirstAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<ProductDTO>> GetProducts(CancellationToken cancellationToken)
        {
            return await dbContext.Products.AsNoTracking()
                .Include(p => p.Reservation)
                .Select(product => new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Category = product.Category,
                    Description = product.Description,
                    Price = product.Price,
                    Size = product.Size,
                    IsReserved = product.Reservation != null ? true : false,
                    Section = product.Section,
                    Image = product.Image,

                }).Where(product => product.IsReserved == false)
                .ToListAsync(cancellationToken);
        }

        public async Task UpdateProduct(UpdateProductDTO updateProductDTO, CancellationToken cancellationToken)
        {
            Product product = await dbContext.Products.FindAsync(new object[] { updateProductDTO.Id }, cancellationToken: cancellationToken);

            if (product != null)
            {
                product.Name = updateProductDTO.Name;
                product.Description = updateProductDTO.Description;
                product.CategoryId = product.CategoryId;
                product.Price = updateProductDTO.Price;
                product.Size = updateProductDTO.Size;
                product.SectionId = updateProductDTO.SectionId;
                product.Image = updateProductDTO.Image;
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
