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
    public class DbOrganizationRepository : IOrganizationRepository
    {
        private readonly ExperienceManagementDbContext _uow;
        public DbOrganizationRepository(ExperienceManagementDbContext uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
        }
        public async Task<long> AddOrganizationAsync(User user, string organizationName, string description, long? parentId)
        {
            try
            {               
                Organization parent = null;
                if (parentId != null)
                    parent = _uow.Organizations.FirstOrDefault(c => c.ParentId == parentId);                         
                    var isDuplicateOrg = _uow.Organizations.Any(c => c.OrganizationName == organizationName);
                    if (!isDuplicateOrg)
                    {
                        var org = new Organization()
                        {
                            Description = description,
                            OrganizationName = organizationName,
                            ParentId = parentId
                        };
                        await _uow.Organizations.AddAsync(org);
                        await _uow.SaveChangesAsync();
                        return org.Id;
                    }
                    throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DbAddDuplicateOrganizationError);                             
            }

            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DbAddOrganizationError, ex);
            }
        }

        public async Task<bool> DeleteOrganizationAsync(User user, List<long> orgIds)
        {
            try
            {                
                foreach (var orgid in orgIds)
                {
                    if (_uow.Users.Any(c => c.OrganizationId==orgid))
                    {
                        throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.UserInOrganizationExistError);
                    }
                    var parent = _uow.Organizations.Include(p => p.Children)
                               .SingleOrDefault(p => p.Id == orgid);

                    foreach (var child in parent.Children.ToList())
                    {
                        if (!orgIds.Contains(child.Id))
                        {
                            throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DeleteOrgNotselectedError);
                        }
                        await DeleteOrganizationByChildAsync(child, orgIds);
                        _uow.Organizations.Remove(child);
                    }
                    _uow.Organizations.Remove(parent);                    
                }
                _uow.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DbDeleteOrganizationError, ex);
            }
        }

        private async Task DeleteOrganizationByChildAsync(Organization child,List<long> orgIds)
        {
            if (_uow.Users.Any(c => c.OrganizationId == child.Id))
            {
                throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.UserInOrganizationExistError);
            }
            var parentOrg = _uow.Organizations.Include(p => p.Children)
                       .SingleOrDefault(p => p.Id == child.Id);

            foreach (var childorg in parentOrg.Children.ToList())
            {
                if (!orgIds.Contains(childorg.Id))
                {
                    throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DeleteOrgNotselectedError);
                }
                await DeleteOrganizationByChildAsync(childorg, orgIds);
                _uow.Organizations.Remove(child);
            }
        }

        public async Task<bool> EditOrganizationAsync(User user, long organizationId, string organizationName, string description, long? parentId)
        {
            try
            {
                Organization org = null;
                org = _uow.Organizations.FirstOrDefault(c => c.Id == organizationId);
                if (org!=null)
                {
                    var isDuplicateOrg = _uow.Organizations.Any(c => c.OrganizationName == organizationName && c.Id != organizationId);
                    if (!isDuplicateOrg)
                    {
                        org.Description = description;
                        org.OrganizationName = organizationName;
                        org.ParentId = parentId;
                        org.LastUpdateDate = DateTime.Now;
                        _uow.Organizations.Update(org);
                        await _uow.SaveChangesAsync();
                        return true;
                    }
                    throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DbEditDuplicateOrganizationError);
                }
                throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DbEditOrganizationNotExistError);
            }

            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DbEditOrganizationError, ex);
            }
        }

        public async Task<List<Organization>> GetOrganizationByUserAsync(User user)
        {
            if (user.IsAdmin())
            {
                var organizations = await _uow.Organizations.ToListAsync();
                return organizations;
            }
            else
            {
                var organizations = await _uow.Organizations.Where(x => x.ParentId == user.OrganizationId).SelectMany(x => x.Children).ToListAsync();
                return organizations;
            }
        }
    }
}
