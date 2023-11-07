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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));

            builder.Property(person => person.Name).IsRequired();
            builder.Property(person => person.Surname).IsRequired();
            builder.Property(person => person.Email).IsRequired();
            builder.Property(person => person.Username).IsRequired();
            builder.Property(person => person.Password).IsRequired();
            builder.HasIndex(person => person.Email).IsUnique();
            builder.HasOne(person => person.Role)
                .WithMany(role => role.People)
                .HasForeignKey(person => person.RoleId);

            builder
                .HasMany(r => r.Reservations)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);

            builder.HasKey(person => person.Id);
        }
    }
}
