using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Extensions;
using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;

namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Implement
{
    public class DbRolesRepository:IRolesRepository
    {
        private readonly ExperienceManagementDbContext _uow;
        public DbRolesRepository(ExperienceManagementDbContext uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
        }

        public Task<List<Role>> FindUserRolesAsync(Guid userId)
        {
            var userRolesQuery = from role in _uow.Roles
                                 from userRoles in role.UserRoles
                                 where userRoles.UserId == userId
                                 select role;
            return userRolesQuery.OrderBy(x => x.Name).ToListAsync();
        }

        public Task<List<User>> FindUsersInRoleAsync(string roleName)
        {
            var roleUserIdsQuery = from role in _uow.Roles
                                   where role.Name == roleName
                                   from user in role.UserRoles
                                   select user.UserId;
            return _uow.Users.Where(user => roleUserIdsQuery.Contains(user.Id))
                         .ToListAsync();
        }

        public async Task<Role> FirstOrDefaultUserRoleAsync(Guid userId, string roleName)
        {
            var userRolesQuery = from role in _uow.Roles
                                 where role.Name == roleName
                                 from user in role.UserRoles
                                 where user.UserId == userId
                                 select role;
            return await userRolesQuery.FirstOrDefaultAsync();
        }

        public async Task<List<Role>> GetRolesAsync()
        {           
                var roles = await _uow.Roles.ToListAsync();
                return roles;           
        }
    }
}
