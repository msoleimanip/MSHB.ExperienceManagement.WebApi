using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.Tree;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        public async Task<OrganizationViewModel> GetAsync(User user,long Id)
        {
            var organization = await _organizationRepository.GetOrganizationByIdAsync(user,Id);
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

        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
            _organizationRepository.CheckArgumentIsNull(nameof(_organizationRepository));
        }

        public async Task<List<JsTreeNode>> GetOrganizationByUserAsync(User user)
        {
            var organizations = await _organizationRepository.GetOrganizationByUserAsync(user);
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
                var orgId = await _organizationRepository.AddOrganizationAsync(user, orgForm.OrganizationName, orgForm.Description, orgForm.ParentId);
                return orgId;
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
                var res = await _organizationRepository.EditOrganizationAsync(user, orgForm.OrganizationId, orgForm.OrganizationName, orgForm.Description, orgForm.ParentId);
                return res;
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
                var res = await _organizationRepository.DeleteOrganizationAsync(user, orgIds);
                return res;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(OrganizationServiceErrors.DeleteOrganizationError, ex);
            }
        }

    }
}
