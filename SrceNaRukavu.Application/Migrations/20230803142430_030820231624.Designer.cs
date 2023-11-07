﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SrceNaRukavu.Application.Persistence;

#nullable disable

namespace SrceNaRukavu.Application.Migrations
{
    [DbContext(typeof(SrceNaRukavuDbContext))]
    [Migration("20230803142430_030820231624")]
    partial class _030820231624
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.Property<int>("CartsId")
                        .HasColumnType("int");

                    b.Property<int>("ProductsId")
                        .HasColumnType("int");

                    b.HasKey("CartsId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("CartProduct");
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Authenticate", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authenticates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "1234",
                            Token = "",
                            Username = "bossman"
                        });
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AuthenticateId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Person", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Teslina ulica 7",
                            AuthenticateId = 1,
                            City = "Zagreb",
                            Email = "anak@gmail.com",
                            Name = "Ana",
                            RoleId = 2,
                            Surname = "K.",
                            Telephone = "0913340123"
                        });
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SectionId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "SYSADM",
                            Name = "System admin"
                        },
                        new
                        {
                            Id = 2,
                            Code = "OWN",
                            Name = "Owner"
                        },
                        new
                        {
                            Id = 3,
                            Code = "MAN",
                            Name = "Manager"
                        },
                        new
                        {
                            Id = 4,
                            Code = "CUS",
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Anin odjel"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Prijateljev odjel"
                        });
                });

            modelBuilder.Entity("CartProduct", b =>
                {
                    b.HasOne("SrceNaRukavu.Domain.Cart", null)
                        .WithMany()
                        .HasForeignKey("CartsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SrceNaRukavu.Domain.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Authenticate", b =>
                {
                    b.HasOne("SrceNaRukavu.Domain.Person", "Person")
                        .WithOne("Authenticate")
                        .HasForeignKey("SrceNaRukavu.Domain.Authenticate", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Cart", b =>
                {
                    b.HasOne("SrceNaRukavu.Domain.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Person", b =>
                {
                    b.HasOne("SrceNaRukavu.Domain.Role", "Role")
                        .WithMany("People")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Product", b =>
                {
                    b.HasOne("SrceNaRukavu.Domain.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SrceNaRukavu.Domain.Section", "Section")
                        .WithMany("Products")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Person", b =>
                {
                    b.Navigation("Authenticate")
                        .IsRequired();
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Role", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("SrceNaRukavu.Domain.Section", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
