using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{  
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
            _rolesRepository.CheckArgumentIsNull(nameof(_rolesRepository));
        }

        public async Task<List<Role>> FindUserRolesAsync(Guid userId)
        {
            try
            {
                return await _rolesRepository.FindUserRolesAsync(userId);
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(RolesServiceErrors.FindUserRolesError, ex);
            }
            
           
        }

        public async Task<bool> IsUserInRole(Guid userId, string roleName)
        {
            try
            {
                return await _rolesRepository.FirstOrDefaultUserRoleAsync(userId, roleName) != null;
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(RolesServiceErrors.GetIsUserInRoleError, ex);
            }
            
        }

        public Task<List<User>> FindUsersInRoleAsync(string roleName)
        {
            try
            {
                return _rolesRepository.FindUsersInRoleAsync(roleName);
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(RolesServiceErrors.GetFindUsersInRoleError, ex);
            }
            
           
        }
        public async Task<List<RoleViewModel>> GetRolesAsync(User user)
        {
            try
            {
                var roles = await _rolesRepository.GetRolesAsync();
                return roles.Select(x => new RoleViewModel
                {
                    RoleId = x.Id,
                    Name = x.Name,
                    Title = x.Title
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(RolesServiceErrors.GetRolesError, ex);
            }
        }
    }
}