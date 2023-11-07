using SrceNaRukavu.Application.People.Models;
using SrceNaRukavu.Application.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Products
{
    public interface IProductService
    {
        public Task<IReadOnlyList<ProductDTO>> GetProducts(CancellationToken cancellationToken);
        public Task<ProductDTO> GetProductById(int id,CancellationToken cancellationToken);
        public Task<int> CreateProduct(CreateProductDTO createProductDTO,CancellationToken cancellationToken);
        public Task UpdateProduct(UpdateProductDTO updateProductDTO, CancellationToken cancellationToken);
        public Task<bool> DeleteProduct(int id,CancellationToken cancellationToken);
    }
}
