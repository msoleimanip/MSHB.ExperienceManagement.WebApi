using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.Tree;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Extensions;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class OrganizationService : IOrganizationService
    {
        private readonly ExperienceManagementDbContext _context;

        public OrganizationService(ExperienceManagementDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }

        public async Task<OrganizationViewModel> GetAsync(User user, long Id)
        {
            try
            {
                var organization = await _context.Organizations.FindAsync(Id);
                if (organization != null)
                {
                    return new OrganizationViewModel()
                    {
                        Id = organization.Id,
                        OrganizationName = organization.OrganizationName,
                        Description = organization.Description,
                        ParentId = organization.ParentId
                    };
                }
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.OrganizationNotFoundError);
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.GetOrganizationError, ex);
            }
        }

        public async Task<List<JsTreeNode>> GetOrganizationByUserAsync(User user)
        {
            var organizations = new List<Organization>();
            if (user.IsAdmin())
            {
                organizations = await _context.Organizations.ToListAsync();
            }
            else
            {
                organizations = await _context.Organizations.Where(x => x.ParentId == user.OrganizationId).SelectMany(x => x.Children).ToListAsync();
            }
            var organizationnodes = new List<JsTreeNode>();
            organizations.ForEach(or =>
            {
                if (or.ParentId == null)
                {
                    JsTreeNode parentNode = new JsTreeNode();
                    parentNode.id = or.Id.ToString();
                    parentNode.text = or.OrganizationName;
                    parentNode = FillChild(organizations, parentNode, or.Id);
                    organizationnodes.Add(parentNode);
                }

            });
            return organizationnodes;
        }
        private JsTreeNode FillChild(List<Organization> organizations, JsTreeNode parentNode, long Id)
        {
            if (organizations.Count > 0)
            {
                organizations.ForEach(or =>
                {
                    if (or.ParentId == Id)
                    {
                        JsTreeNode parentNodeChild = new JsTreeNode();
                        parentNodeChild.id = or.Id.ToString();
                        parentNodeChild.text = or.OrganizationName;
                        parentNode.children.Add(parentNodeChild);
                        FillChild(organizations, parentNodeChild, or.Id);
                    }
                });
            }
            return parentNode;
        }
        public async Task<long> AddOrganizationAsync(User user, AddOrgFormModel orgForm)
        {
            try
            {
                Organization parent = null;
                if (orgForm.ParentId != null)
                    parent = _context.Organizations.FirstOrDefault(c => c.ParentId == orgForm.ParentId);
                var isDuplicateOrg = _context.Organizations.Any(c => c.OrganizationName == orgForm.OrganizationName);
                if (!isDuplicateOrg)
                {
                    var org = new Organization()
                    {
                        Description = orgForm.Description,
                        OrganizationName = orgForm.OrganizationName,
                        ParentId = orgForm.ParentId
                    };
                    await _context.Organizations.AddAsync(org);
                    await _context.SaveChangesAsync();
                    return org.Id;
                }
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.AddDuplicateOrganizationError);

            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.AddOrganizationError, ex);
            }


        }

        public async Task<bool> EditOrganizationAsync(User user, EditOrgFormModel orgForm)
        {
            try
            {
                Organization org = null;
                org = _context.Organizations.FirstOrDefault(c => c.Id == orgForm.OrganizationId);
                if (org != null)
                {
                    var isDuplicateOrg = _context.Organizations.Any(c => c.OrganizationName == orgForm.OrganizationName && c.Id != orgForm.OrganizationId);
                    if (!isDuplicateOrg)
                    {
                        org.Description = orgForm.Description;
                        org.OrganizationName = orgForm.OrganizationName;
                        org.ParentId = orgForm.ParentId;
                        org.LastUpdateDate = DateTime.Now;
                        _context.Organizations.Update(org);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    throw new ExperienceManagementGlobalException(OrganizationServiceErrors.EditDuplicateOrganizationError);
                }
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.EditOrganizationNotExistError);

            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.EditOrganizationError, ex);
            }
        }

        public async Task<bool> DeleteOrganizationAsync(User user, List<long> orgIds)
        {
            try
            {

                foreach (var orgid in orgIds)
                {
                    if (_context.Users.Any(c => c.OrganizationId == orgid))
                    {
                        throw new ExperienceManagementGlobalException(OrganizationServiceErrors.UserInOrganizationExistError);
                    }
                    var parent = _context.Organizations.Include(p => p.Children)
                               .SingleOrDefault(p => p.Id == orgid);

                    foreach (var child in parent.Children.ToList())
                    {
                        if (!orgIds.Contains(child.Id))
                        {
                            throw new ExperienceManagementGlobalException(OrganizationServiceErrors.DeleteOrgNotselectedError);
                        }
                        await DeleteOrganizationByChildAsync(child, orgIds);
                        _context.Organizations.Remove(child);
                    }
                    _context.Organizations.Remove(parent);
                }
                _context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.DeleteOrganizationError, ex);
            }
        }
        private async Task DeleteOrganizationByChildAsync(Organization child, List<long> orgIds)
        {
            if (_context.Users.Any(c => c.OrganizationId == child.Id))
            {
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.UserInOrganizationExistError);
            }
            var parentOrg = _context.Organizations.Include(p => p.Children)
                       .SingleOrDefault(p => p.Id == child.Id);

            foreach (var childorg in parentOrg.Children.ToList())
            {
                if (!orgIds.Contains(childorg.Id))
                {
                    throw new ExperienceManagementGlobalException(OrganizationServiceErrors.DeleteOrgNotselectedError);
                }
                await DeleteOrganizationByChildAsync(childorg, orgIds);
                _context.Organizations.Remove(child);
            }
        }

    }
}
