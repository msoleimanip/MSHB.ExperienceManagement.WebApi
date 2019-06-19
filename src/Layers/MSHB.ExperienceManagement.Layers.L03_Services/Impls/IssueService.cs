using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class IssueService: IIssueService
    {
        private readonly ExperienceManagementDbContext _context;

        public IssueService(ExperienceManagementDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }

        public Task<bool> AddIssueAsync(User user, AddIssueFormModel issueForm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditIssueAsync(User user, EditIssueFormModel issueForm)
        {
            throw new NotImplementedException();
        }
    }
}
