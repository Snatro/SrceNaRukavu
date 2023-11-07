using SrceNaRukavu.Application.Categories.Models;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Products.Models
{
    public class ProductSimpleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }

        public static ProductSimpleDTO FromModel(Product model)
        {
            return new ProductSimpleDTO
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Size = model.Size,
                Image = model.Image
            };
        }
    }
}
