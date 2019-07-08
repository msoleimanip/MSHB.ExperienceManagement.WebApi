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


        public async Task<ReportStructureViewModel> GetReportStructureAsync(ReportStructureFormModel reportStructureFormModel)
        {
            try
            {
                var resp = await _context.ReportStructures.FirstOrDefaultAsync(c => c.ReportId == reportStructureFormModel.ReportId);
                if (resp is null)
                {
                    throw new ExperienceManagementGlobalException(ReportServiceErrors.ReportStructureNotFound);
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

                throw new ExperienceManagementGlobalException(ReportServiceErrors.GetReportStructure, ex);
            }
        }
    }
}
