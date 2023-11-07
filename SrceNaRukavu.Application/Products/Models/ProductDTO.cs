using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Products.Models
{
    public class ProductDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public Category? Category { get; set; }
        public string? Description { get; set; }
        public float? Price { get; set; }
        public string? Size { get; set; }
        public bool? IsReserved { get; set; }
        public Section? Section { get; set; }
        public string? Image { get; set; }
    }
}
