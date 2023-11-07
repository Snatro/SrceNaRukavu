using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));  

            builder.Property(product => product.Name).IsRequired();
            builder.Property(product => product.Description).IsRequired();
            builder.Property(product => product.Price).IsRequired();
            builder.Property(product => product.Size).IsRequired();
            builder.Property(product => product.Image).IsRequired();

            builder.HasOne(product => product.Section)
                .WithMany(section => section.Products)
                .HasForeignKey(product => product.SectionId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasOne(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
