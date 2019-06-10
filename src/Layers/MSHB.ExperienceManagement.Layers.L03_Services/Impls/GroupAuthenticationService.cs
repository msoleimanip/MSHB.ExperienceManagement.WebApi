using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using System.Linq;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
  
    public class GroupAuthenticationService : IGroupAuthenticationService
    {
        private readonly IGroupAuthenticationRepository _groupAuthenticationRepository;
        public GroupAuthenticationService(IGroupAuthenticationRepository groupAuthenticationRepository)
        {
            _groupAuthenticationRepository = groupAuthenticationRepository;
            _groupAuthenticationRepository.CheckArgumentIsNull(nameof(_groupAuthenticationRepository));
        }
        public async Task<List<GroupAuthenticationViewModel>> GetGroupAuthenticationAsync()
        {
            var groupAuthentications = await _groupAuthenticationRepository.GetGroupAuthenticationAsync();
            return groupAuthentications.Select(x => new GroupAuthenticationViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }
        public async Task<List<RoleViewModel>> GetRolesAsync(User user)
        {
            try
            {
                var roles = await _groupAuthenticationRepository.GetRolesAsync();
                return roles.Select(x => new RoleViewModel
                {
                    RoleId = x.Id,
                    Name = x.Name,
                    Title = x.Title
                }).ToList();
            }
            catch(Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupServiceErrors.GetRolesError,ex);
            }
        }
        public Task<long> AddGroupAsync(User user, AddGroupFormModel groupForm)
        {          
            throw new NotImplementedException();
        }

        public Task<bool> DeleteGroupAsync(User user, List<long> groupIds)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditGroupAsync(User user, EditGroupFormModel groupForm)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RoleViewModel>> GetGroupRoleAsync(User user, long Id)
        {
           try
            {
                var roles = await _groupAuthenticationRepository.GetRolesAsync();
                return roles.Select(x => new RoleViewModel
                {
                    RoleId = x.Id,
                    Name = x.Name,
                    Title = x.Title
                }).ToList();
            }
            catch(Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupServiceErrors.GetRolesError,ex);
            }
        }
    }
}
