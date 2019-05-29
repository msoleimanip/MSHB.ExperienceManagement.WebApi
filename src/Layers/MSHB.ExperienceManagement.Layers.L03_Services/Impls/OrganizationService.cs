using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.Tree;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;


        public OrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
            _organizationRepository.CheckArgumentIsNull(nameof(_organizationRepository));
        }
        public async Task<List<JsTreeNode>> GetOrganizationByUserAsync(User user)
        {
            var organizations =await  _organizationRepository.GetOrganizationByUserAsync(user);
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
    }
}
