using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Products.Models
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Size { get; set; }
        public int SectionId { get; set; }
        public string Image { get; set; }
    }
}
