using SrceNaRukavu.Application.Roles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrceNaRukavu.Application.Roles
{
    public interface IRoleService
    {
        public Task<IReadOnlyList<RoleDTO>> GetRoles(CancellationToken cancellationToken);
        public Task<RoleDTO> GetRoleByID(int id, CancellationToken cancellationToken);
    }
}
