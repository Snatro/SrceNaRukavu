using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SrceNaRukavu.Application.Categories;
using SrceNaRukavu.Application.People;
using SrceNaRukavu.Application.Persistence;
using SrceNaRukavu.Application.Products;
using SrceNaRukavu.Application.Reservations;
using SrceNaRukavu.Application.Roles;
using SrceNaRukavu.Application.Sections;

namespace SrceNaRukavu.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IPersonService,PersonService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<IRoleService,RoleService>();
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<ISectionService,SectionService>();
            services.AddScoped<IReservationService,ReservationService>();

            services.AddDbContext<SrceNaRukavuDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SrceNaRukavuDB"));
            });

            return services;
        }
    }
}
