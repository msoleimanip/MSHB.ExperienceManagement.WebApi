using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using System.Linq;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class ReportService : IReportService
    {
        private readonly ExperienceManagementDbContext _context;
        public ReportService(ExperienceManagementDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));

        }
        public async Task<bool> AddOrUpdateReportStructureAsync(User user, UpdateReportStructureFormModel form)
        {
            try
            {
                var resp = await _context.ReportStructures.FirstOrDefaultAsync(c => c.Id == form.ReportStructureModelId || c.ReportId == form.ReportId);
                if (resp is null && form.ReportStructureModelId != 0)
                {
                    throw new ExperienceManagementGlobalException(ReportServiceErrors.ReportStructureNotFoundError);
                }
                if (resp != null)
                {
                    resp.Configuration = form.Configuration;
                    resp.LastUpdatedDateTime = DateTime.Now;
                    resp.ReportId = form.ReportId;
                    _context.ReportStructures.Update(resp);
                }
                else
                {
                    var report = new ReportStructure()
                    {
                        Configuration = form.Configuration,
                        CreationDate = DateTime.Now,
                        LastUpdatedDateTime = DateTime.Now,
                        ReportId = form.ReportId
                    };
                    await _context.ReportStructures.AddAsync(report);
                }
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(ReportServiceErrors.UpdateReportStructureError, ex);
            }
        }
        public async Task<ReportStructureViewModel> GetReportStructureAsync(ReportStructureFormModel reportStructureFormModel)
        {
            try
            {
                var resp = await _context.ReportStructures.FirstOrDefaultAsync(c => c.ReportId == reportStructureFormModel.ReportId);
                if (resp is null)
                {
                    throw new ExperienceManagementGlobalException(ReportServiceErrors.ReportStructureNotFoundError);
                }
                return new ReportStructureViewModel()
                {
                    ReportStructureId = resp.Id,
                    Configuration = resp.Configuration,
                    CreationDate = resp.CreationDate,
                    ProtoType = resp.ProtoType,
                    LastUpdatedDateTime = resp.LastUpdatedDateTime,
                    ReportId = resp.ReportId
                };
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(ReportServiceErrors.GetReportStructureError, ex);
            }
        }
        public async Task<List<IssueOfUsersViewModel>> IssueOfUsersReportAsync(User user, IssueOfUsersFormModel form)
        {
            try
            {
                var resp = await _context.Users.Include(c => c.Organization).Include(c => c.Issues).Include(c => c.IssueDetails).Where(c => form.Users.Contains(c.Id)).ToListAsync();

                var issueOfUsersViewModels = new List<IssueOfUsersViewModel>();

                resp?.ToList().ForEach(c =>
               {
                   var issueOfUsersViewModel = new IssueOfUsersViewModel()
                   {
                       FullName = c.FirstName + " " + c.LastName,
                       OrganizationName = c.Organization.OrganizationName,
                       TotalIssueCount = c.Issues.Count,
                       TotalIssueUserDetails = c.IssueDetails.Count,

                   };
                   issueOfUsersViewModels.Add(issueOfUsersViewModel);

               });


                return issueOfUsersViewModels;

            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(ReportServiceErrors.IssueOfUsersReportError, ex);
            }
        }


        public async Task<List<IssuesOfOrganizationViewModel>> IssuesOfOrganizationReportAsync(User user, IssueOfOrganizationFormModel form)
        {
            try
            {
                var resp = await _context.Users.Include(c => c.Issues).Include(c => c.Organization).Where(c => c.OrganizationId != null && form.OrgIds.Contains((long)c.OrganizationId)).ToListAsync();

                var issueOfOrganizationsViewModels = new List<IssuesOfOrganizationViewModel>();
                var result = resp.GroupBy(c => c.OrganizationId);

                //result?.ToList().ForEach(c =>
                //{
                //    var issueOfUsersViewModel = new IssuesOfOrganizationViewModel()
                //    {
                //        TotalUsers=
                //        OrganizationName = c.,
                //        TotalIssueCount = c.Issues.Count,
                       

                //    };
                //    issueOfOrganizationsViewModels.Add(issueOfUsersViewModel);

                //});


                return issueOfOrganizationsViewModels;

            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(ReportServiceErrors.IssuesOfOrganizationReportError, ex);
            }
        }
        public Task<List<TotalIssueViewModel>> TotalIssueReportAsync(User user, IssueOfEquipmentFormModel form)
        {
            throw new NotImplementedException();
        }
        public Task<List<TotalIssueViewModel>> UserIssuesReportAsync(User user, IssueOfEquipmentFormModel form)
        {
            throw new NotImplementedException();
        }
        public Task<List<IssueOfEquipmentViewModel>> IssueOfEquipmentsReportAsync(User user, IssueOfEquipmentFormModel form)
        {
            throw new NotImplementedException();
        }
        public Task<List<IssueOfUserLikesViewModel>> IssueOfUserLikesReportAsync(User user, IssueOfUsersFormModel form)
        {
            throw new NotImplementedException();
        }
    }
}
