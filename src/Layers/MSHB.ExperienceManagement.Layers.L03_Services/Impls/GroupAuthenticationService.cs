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
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Search.Models;

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
        public async Task<long> AddGroupAsync(User user, AddGroupFormModel groupForm)
        {
            try
            {
                var sameGroup = await _groupAuthenticationRepository.SearchGroupAsync(new GroupSearchModel()
                {
                    Name = groupForm.Name
                });

                if (sameGroup.Count>0)
                {
                    throw new ExperienceManagementGlobalException(GroupServiceErrors.SameGroupExistError);
                }
                var group = await _groupAuthenticationRepository.AddGroupAsync(user,groupForm);
                return group;
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(GroupServiceErrors.AddGroupError, ex);
            }
        }

        public async Task<bool> DeleteGroupAsync(User user, List<long> groupIds)
        {
            try
            {               
                var group = await _groupAuthenticationRepository.DeleteGroupAsync(user, groupIds);
                return group;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupServiceErrors.DeleteGroupError, ex);
            }
        }

        public async Task<bool> EditGroupAsync(User user, EditGroupFormModel groupForm)
        {
            try
            {

                var resp = await _groupAuthenticationRepository.EditGroupAsync(user, groupForm);
                return resp;
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(GroupServiceErrors.EditGroupError, ex);
            }
        }

        public async Task<List<RoleViewModel>> GetGroupRoleAsync(User user, long Id)
        {
           try
            {
                var roles = await _groupAuthenticationRepository.GetGroupRoleAsync(Id);
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
