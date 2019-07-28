using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IReportService
    {
        Task<ReportStructureViewModel> GetReportStructureAsync(ReportStructureFormModel reportStructureFormModel);
        Task<bool> AddOrUpdateReportStructureAsync(User user, UpdateReportStructureFormModel form);
        Task<List<IssueOfUsersViewModel>> IssueOfUsersReportAsync(User user, IssueOfUsersFormModel form);
        Task<List<IssueOfEquipmentViewModel>> IssueOfEquipmentsReportAsync(User user, IssueOfEquipmentFormModel form);
        Task<List<IssueOfUserLikesViewModel>> IssueOfUserLikesReportAsync(User user, IssueOfUsersFormModel form);
        Task<List<TotalIssueViewModel>> TotalIssueReportAsync(User user, TotalIssueFormModel form);
        Task<List<TotalIssueViewModel>> UserIssuesReportAsync(User user, IssueOfEquipmentFormModel form);
        Task<List<IssuesOfOrganizationViewModel>> IssuesOfOrganizationReportAsync(User user, IssueOfOrganizationFormModel form);
    }
}
