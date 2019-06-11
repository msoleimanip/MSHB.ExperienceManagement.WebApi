using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Search.Models;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;

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

        public async Task<long> AddGroupAsync(User user, AddGroupFormModel groupForm)
        {
            try
            {
                if ( _uow.Roles.Any(c => !groupForm.RoleIds.Contains(c.Id)))
                {
                    throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbRoleExistError);
                    
                }
                var group = new GroupAuth()
                {
                    Name = groupForm.Name,
                    Description = groupForm.Description
                };
                _uow.GroupAuths.Add(group);

                foreach (var gfRole in groupForm.RoleIds)
                {
                    var groupAuthRole = new GroupAuthRole()
                    {
                        RoleId = gfRole,
                        GroupAuthId = group.Id
                    };
                    _uow.GroupAuthRoles.Add(groupAuthRole);
                }
                await _uow.SaveChangesAsync();
                return group.Id;

            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbAddGroupError,ex);
            }

        }

        public async Task<bool> DeleteGroupAsync(User user, List<long> groupIds)
        {
            try
            {
                if (_uow.GroupAuths.Any(c => !groupIds.Contains(c.Id)))
                {
                    throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DeleteGroupNotselectedError);

                }
                if (_uow.GroupAuths.Where(c=>groupIds.Contains(c.Id)).Include(c=>c.Users).Any())
                {
                    throw new ExperienceManagementGlobalException(GroupRepositoryErrors.UserInGroupExistError);

                }     
                _uow.GroupAuths.RemoveRange(_uow.GroupAuths.Where(c=>groupIds.Contains(c.Id)));              
                await _uow.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbAddGroupError, ex);
            }
        }

        public async Task<bool> EditGroupAsync(User user, EditGroupFormModel groupForm)
        {
            try
            {
               GroupAuth group = null;
                if (_uow.Roles.Any(c => !groupForm.RoleIds.Contains(c.Id)))
                {
                    throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbRoleExistError);

                }
                group = _uow.GroupAuths.Include(c=>c.Users).Include(c=>c.GroupRoles).FirstOrDefault(c => c.Id == groupForm.GroupId);
                if (group != null)
                {
                    var isDuplicategroup = _uow.GroupAuths.Any(c => c.Name == groupForm.Name && c.Id != groupForm.GroupId);
                    if (!isDuplicategroup)
                    {
                        var oldRoleIds = group.GroupRoles.Select(c => c.RoleId).ToList();
                        IEnumerable<long> differencesFirst = groupForm.RoleIds.Except(oldRoleIds).Union(oldRoleIds.Except(groupForm.RoleIds));
                        IEnumerable<long> differencesSecond = groupForm.RoleIds.Union(oldRoleIds).Except(groupForm.RoleIds.Intersect(oldRoleIds));
                        if (differencesFirst.Count()>0 || differencesSecond.Count()>0)
                        {
                            foreach (var gpUser in group.Users.ToList())
                            {
                                _uow.UserRoles.RemoveRange(_uow.UserRoles.Where(c => c.UserId == gpUser.Id).ToList());
                            }
                            foreach (var gpUser in group.Users.ToList())
                            {
                                var newUserRoles = groupForm.RoleIds.Select(roleId =>
                                                new UserRole
                                                {
                                                    UserId = gpUser.Id,
                                                    RoleId = roleId
                                                }).ToList();                                                  
                                _uow.UserRoles.AddRange(newUserRoles);
                            }
                        }
                        group.Name = groupForm.Name;
                        group.Description = groupForm.Description;
                        await _uow.SaveChangesAsync();
                        return true;
                    }
                    throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbEditDuplicateGroupError);
                }
                throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbEditGroupNotExistError);

            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbAddGroupError, ex);
            }
        }

        public async Task<List<GroupAuth>> GetGroupAuthenticationAsync()
        {
            var groupAuths = await _uow.GroupAuths.ToListAsync();
            return groupAuths;
        }

        public async Task<List<Role>> GetGroupRoleAsync(long id)
        {
            try
            {
                var groupRoles = await _uow.GroupAuthRoles.Where(c=>c.GroupAuthId==id).Include(c=>c.Role).Select(c=>c.Role).ToListAsync();
                return groupRoles;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbGetGroupError, ex);
                
            }
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            try
            {
                var roles = await _uow.Roles.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbGetRolesError, ex);

            }
        }

        public async Task<List<GroupAuth>> SearchGroupAsync(GroupSearchModel groupmodel)
        {
            try
            {
                var groupAuths = _uow.GroupAuths.AsQueryable();
                if (!string.IsNullOrEmpty(groupmodel.Name))
                {
                    groupAuths=groupAuths.Where(c => c.Name == groupmodel.Name);
                }
                if (!string.IsNullOrEmpty(groupmodel.Description))
                {
                    groupAuths = groupAuths.Where(c => c.Description == groupmodel.Description);
                }
                if (groupmodel.GroupId.HasValue && groupmodel.GroupId !=0)
                {
                    groupAuths = groupAuths.Where(c => c.Id == groupmodel.GroupId);
                }
                var groups = await groupAuths.ToListAsync();
                return groups;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(GroupRepositoryErrors.DbGetRolesError, ex);

            }
        }
    }
}
