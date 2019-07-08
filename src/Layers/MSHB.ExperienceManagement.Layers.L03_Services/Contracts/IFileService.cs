using Microsoft.AspNetCore.Http;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Contracts
{
    public interface IFileService
    {
        Task<Guid> UploadAsync(User user, IFormFile file);
        Task<DownloadViewModel> DownloadAsync(User user, Guid fileId);
    }
}
