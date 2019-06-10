using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Implement
{
    public class DbGroupAuthenticationRepository : IGroupAuthenticationRepository
    {
        private readonly ExperienceManagementDbContext _uow;
        public DbGroupAuthenticationRepository(ExperienceManagementDbContext uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
        }

        public async Task<List<GroupAuth>> GetGroupAuthenticationAsync()
        {
            var groupAuths = await _uow.GroupAuths.ToListAsync();
            return groupAuths;
        }

        public Task<List<Role>> GetGroupRoleAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Role>> GetRolesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
