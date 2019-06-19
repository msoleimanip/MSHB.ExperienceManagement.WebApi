using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Settings;
using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class IssueService: IIssueService
    {
        private readonly ExperienceManagementDbContext _context;
        private readonly IOptionsSnapshot<SiteSettings> _siteSettings;

        public IssueService(ExperienceManagementDbContext context, IOptionsSnapshot<SiteSettings> siteSettings)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
            _siteSettings = siteSettings;
            _siteSettings.CheckArgumentIsNull(nameof(_siteSettings));
        }

        public async Task<bool> AddIssueAsync(User user, AddIssueFormModel issueForm)
        {
            try
            {
                var issue = new Issue();
                FileAddress fileAddress;
                if (issueForm.ImageId!=null)
                {
                    fileAddress = await _context.FileAddresses.FindAsync(issueForm.ImageId);
                    if (fileAddress == null)
                    {
                        throw new ExperienceManagementGlobalException(IssueServiceErrors.UploadFileNotFound);
                    }
                    try
                    {
                        Image image = Image.FromFile(fileAddress.FilePath);
                        Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                        var newPath = Path.ChangeExtension(fileAddress.FilePath, "thumb");
                        thumb.Save(newPath);
                        issue.ImageAddress = newPath;
                    }
                    catch (Exception ex)
                    {

                        throw new ExperienceManagementGlobalException(IssueServiceErrors.ChangeToThumbnailError,ex);
                    }
                    
                }
                issue.IsActive = false;
                issue.IssueType = (IssueType)issueForm.IssueType;
                issue.Title = issueForm.Title;
                issue.Description = issue.Description;
                issue.CreationDate = DateTime.Now;
                issue.LastUpdateDate = DateTime.Now;
                issue.UserId = user.Id;
                await _context.Issues.AddAsync(issue);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(IssueServiceErrors.UploadFileError, ex);
            }
        }

        public async Task<bool> AddIssueDetailAsync(User user, AddIssueDetailFormModel issueDetailForm)
        {
            try
            {
                var issue = await _context.Issues.FindAsync(issueDetailForm.IssueId);
                if (issue is null)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.IssueNotFoundError);
                }
                var userReq = await _context.Users.FindAsync(issueDetailForm.UserId);
                if (userReq is null)
                {
                    throw new ExperienceManagementGlobalException(UsersServiceErrors.UserNotFoundError);
                }
                var issueDetail = new IssueDetail()
                {
                    IssueId = issue.Id,
                    CreationDate = DateTime.Now,
                    Title = issueDetailForm.Title,
                    Description = issueDetailForm.Description,
                    UserId = issueDetailForm.UserId,

                };
                await _context.IssueDetails.AddAsync(issueDetail);
                if (issueDetailForm.UploadFiles!=null && issueDetailForm.UploadFiles.Count > 0)
                {
                    var notFoundFiles = 0;
                    var filesAddress = new List<FileAddress>();
                    issueDetailForm.UploadFiles.ForEach( uf =>
                    {
                        var fileAddress =  _context.FileAddresses.Find(uf);
                        if (fileAddress == null)
                        {
                            notFoundFiles++;
                        }
                        filesAddress.Add(fileAddress);
                    });
                    if (notFoundFiles > 0)
                    {
                        throw new ExperienceManagementGlobalException(IssueServiceErrors.UploadFileNotFound);
                    }
                    
                    filesAddress.ForEach(async fa => {
                        var issueDetailAttachment = new IssueDetailAttachment() {
                            IssueDetailId = issueDetail.Id,
                            FilePath=fa.FilePath,
                            FileSize=fa.FileSize,
                            FileType=fa.FileType,                           
                        };
                        await _context.IssueDetailAttachments.AddAsync(issueDetailAttachment);
                    });
                }
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(IssueServiceErrors.AddIssueDetailError, ex);
            }
        }

        public Task<bool> EditIssueAsync(User user, EditIssueFormModel issueForm)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> UploadFileAsync(User user, IFormFile file)
        {
            try
            {
                if (string.IsNullOrEmpty(file.FileName)||file.Length==0)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.UploadFileValidError);
                }
                var extension =  file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                var fileName = Guid.NewGuid().ToString() + extension;                                                                  
                var path = Path.Combine(_siteSettings.Value.UserAttachedFile.PhysicalPath, "." + fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
                var uploadFile = new FileAddress()
                {
                    FilePath = path,
                    FileType = extension,
                    UserId = user.Id,
                    FileSize = file.Length,
                    CreationDate = DateTime.Now
                };
                await _context.FileAddresses.AddAsync(uploadFile);
                await _context.SaveChangesAsync();

                return uploadFile.FileId;

            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(IssueServiceErrors.UploadFileError, ex);
            }
        }
    }
}
