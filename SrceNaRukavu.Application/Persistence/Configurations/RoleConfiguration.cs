using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SrceNaRukavu.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Persistence.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role));
            builder.Property(role => role.Name).IsRequired();
            builder.Property(role => role.Code).IsRequired();

            builder
                .HasMany(r => r.People)
                .WithOne(p => p.Role)
                .HasForeignKey(p => p.RoleId);

            builder.HasKey(role => role.Id);
        }
    }
}
