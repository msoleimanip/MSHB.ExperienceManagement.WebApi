using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;

namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts
{
    public interface IRolesRepository
    {
        Task<List<Role>> FindUserRolesAsync(Guid userId);
        Task<Role> FirstOrDefaultUserRoleAsync(Guid userId, string roleName);
        Task<List<User>> FindUsersInRoleAsync(string roleName);
        Task<List<Role>> GetRolesAsync();
    }
}
