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
                var resp = await _context.ReportStructures.FirstOrDefaultAsync(c => c.Id == form.ReportStructureModelId);
                if (resp is null && form.ReportStructureModelId!=0)
                {
                    throw new ExperienceManagementGlobalException(ReportServiceErrors.ReportStructureNotFoundError);
                }
                if (resp!=null)
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

        public Task<List<IssueOfUsersViewModel>> IssueOfUsersReportAsync(User user, IssueOfUsersFormModel form)
        {
            try
            {
                //var resp = await _context.ReportStructures.FirstOrDefaultAsync(c => c.Id == form.ReportStructureModelId);
                //if (resp is null && form.ReportStructureModelId != 0)
                //{
                //    throw new ExperienceManagementGlobalException(ReportServiceErrors.ReportStructureNotFoundError);
                //}
                //if (resp != null)
                //{
                //    resp.Configuration = form.Configuration;
                //    resp.LastUpdatedDateTime = DateTime.Now;
                //    resp.ReportId = form.ReportId;
                //    _context.ReportStructures.Update(resp);
                //}
                //else
                //{
                //    var report = new ReportStructure()
                //    {
                //        Configuration = form.Configuration,
                //        CreationDate = DateTime.Now,
                //        LastUpdatedDateTime = DateTime.Now,
                //        ReportId = form.ReportId
                //    };
                //    await _context.ReportStructures.AddAsync(report);
                //}
                //await _context.SaveChangesAsync();
                //return true;
                throw new ExperienceManagementGlobalException(ReportServiceErrors.IssueOfUsersReportError);

            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(ReportServiceErrors.IssueOfUsersReportError, ex);
            }
        }
    }
}
