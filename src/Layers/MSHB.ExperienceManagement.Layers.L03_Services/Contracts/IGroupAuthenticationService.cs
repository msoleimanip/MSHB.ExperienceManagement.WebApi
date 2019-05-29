using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IGroupAuthenticationService
    {
        Task<List<GroupAuthenticationViewModel>> GetGroupAuthenticationAsync();

    }
}
