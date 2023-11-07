using Microsoft.EntityFrameworkCore;
using SrceNaRukavu.Application.Persistence;
using SrceNaRukavu.Application.Roles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Roles
{
    public class RoleService : IRoleService
    {
        private readonly SrceNaRukavuDbContext dbContext;
        public RoleService(SrceNaRukavuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<RoleDTO> GetRoleByID(int id, CancellationToken cancellationToken)
        {
            var a = await dbContext.Roles.Include(role => role.People).Where(role => role.Id == id).FirstAsync(cancellationToken);

            return null;
        }

        public async Task<IReadOnlyList<RoleDTO>> GetRoles(CancellationToken cancellationToken)
        {
            return await dbContext.Roles.AsNoTracking()
               .Select(role => new RoleDTO
               {
                   Id = role.Id,
                   Name = role.Name,
                   Code = role.Code,
               }).ToListAsync(cancellationToken);
        }
    }
}
