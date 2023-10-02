using AccountManagement.Application.Contracts.Role;
using System.Collections.Generic;
using _0_Framework.Domain;

namespace AccountManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<long,Role> 
    {
        List<RoleViewModel> GetRoles();
        EditRole GetDetails(long id);
    }
}
