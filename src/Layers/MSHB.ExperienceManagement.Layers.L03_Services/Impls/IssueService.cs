using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Settings;
using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class IssueService : IIssueService
    {
        private readonly ExperienceManagementDbContext _context;

        public IssueService(ExperienceManagementDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
           
        }

        public async Task<bool> ActivateIssueAsync(User user, ActivateIssueFormModel issueActivate)
        {
            try
            {
                var issue = await _context.Issues.FindAsync(issueActivate.IssueId);
                if (issue is null)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.IssueNotFoundError);
                }
                issue.IsActive = issueActivate.IsActive;
                _context.Issues.Update(issue);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(IssueServiceErrors.ChangeStateIssueError, ex);
            }
        }

        public async Task<long> AddIssueAsync(User user, AddIssueFormModel issueForm)
        {
            try
            {
                var issue = new Issue();
                var userInfo = await _context.Users.FirstOrDefaultAsync(c => c.Id == issueForm.UserId);
                if (userInfo == null)
                {
                    throw new ExperienceManagementGlobalException(UsersServiceErrors.UserNotFoundError);
                }

                FileAddress fileAddress;
                if (issueForm.ImageId != null)
                {
                    fileAddress = await _context.FileAddresses.FindAsync(issueForm.ImageId);
                    if (fileAddress == null)
                    {
                        throw new ExperienceManagementGlobalException(IssueServiceErrors.NotExistFileAddressError);
                    }
                    try
                    {
                        if (!File.Exists(fileAddress.FilePath))
                        {
                            throw new ExperienceManagementGlobalException(IssueServiceErrors.FileNotFoundError);

                        }
                        Image image = Image.FromFile(fileAddress.FilePath);
                        Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                        var newPath = Path.ChangeExtension(fileAddress.FilePath, "thumb");
                        thumb.Save(newPath);
                        fileAddress.FilePath = newPath;
                        fileAddress.FileType = "thumb";
                        _context.FileAddresses.Update(fileAddress);
                        issue.FileId = fileAddress.FileId;
                    }
                    catch (Exception ex)
                    {

                        throw new ExperienceManagementGlobalException(IssueServiceErrors.ChangeToThumbnailError, ex);
                    }

                }
                //var IsExistEquipment = _context.Equipments.All(c => issueForm.EquipmentIds.Contains(c.Id));
                //if (!IsExistEquipment)
                //{
                //    throw new ExperienceManagementGlobalException(IssueServiceErrors.NotExistEquipmentsListError);
                //}
                issueForm.EquipmentIds.ForEach(async resp =>
                {
                    var equipmentIssueSubscription = new EquipmentIssueSubscription();
                    equipmentIssueSubscription.Issue = issue;
                    equipmentIssueSubscription.EquipmentId = resp;
                    await _context.EquipmentIssueSubscriptions.AddAsync(equipmentIssueSubscription);
                });


                issue.IsActive = false;
                issue.IssueType = (IssueType)issueForm.IssueType;
                issue.Title = issueForm.Title;
                issue.Description = issue.Description;
                issue.CreationDate = DateTime.Now;
                issue.LastUpdateDate = DateTime.Now;
                issue.UserId = user.Id;
                await _context.Issues.AddAsync(issue);
                await _context.SaveChangesAsync();
                return issue.Id;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(IssueServiceErrors.AddIssueError, ex);
            }
        }

        public async Task<long> AddIssueDetailAsync(User user, AddIssueDetailFormModel issueDetailForm)
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
                    Caption = issueDetailForm.Caption,
                    Text = issueDetailForm.Text,
                    UserId = issueDetailForm.UserId,
                    LastUpdateDate = DateTime.Now

                };
                issue.AnswerCounts = issue.AnswerCounts + 1;
                issue.LastUpdateDate = DateTime.Now;
                _context.Issues.Update(issue);

                await _context.IssueDetails.AddAsync(issueDetail);
                if (issueDetailForm.UploadFiles != null && issueDetailForm.UploadFiles.Count > 0)
                {
                    var notFoundFiles = 0;
                    var filesAddress = new List<FileAddress>();
                    issueDetailForm.UploadFiles.ForEach(uf =>
                   {
                       var fileAddress = _context.FileAddresses.Find(uf);
                       if (fileAddress == null)
                       {
                           notFoundFiles++;
                       }
                       filesAddress.Add(fileAddress);
                   });
                    if (notFoundFiles > 0)
                    {
                        throw new ExperienceManagementGlobalException(IssueServiceErrors.NotExistFileAddressError);
                    }

                    filesAddress.ForEach(async fa =>
                    {
                        var issueDetailAttachment = new IssueDetailAttachment()
                        {
                            IssueDetails = issueDetail,
                            FileId = fa.FileId,
                            FileSize = fa.FileSize,
                            FileType = fa.FileType,
                        };
                        await _context.IssueDetailAttachments.AddAsync(issueDetailAttachment);
                    });
                }
                await _context.SaveChangesAsync();
                return issueDetail.Id;


            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(IssueServiceErrors.AddIssueDetailError, ex);
            }
        }

        public async Task<bool> EditIssueAsync(User user, EditIssueFormModel issueForm)
        {
            try
            {
                var issue = await _context.Issues.FindAsync(issueForm.IssueId);
                if (issue is null)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.IssueNotFoundError);
                }
                FileAddress fileAddress;
                if (issueForm.ImageId != null)
                {
                    fileAddress = await _context.FileAddresses.FindAsync(issueForm.ImageId);
                    if (fileAddress == null)
                    {
                        throw new ExperienceManagementGlobalException(IssueServiceErrors.NotExistFileAddressError);
                    }
                    try
                    {
                        if (!File.Exists(fileAddress.FilePath))
                        {
                            throw new ExperienceManagementGlobalException(IssueServiceErrors.FileNotFoundError);

                        }
                        Image image = Image.FromFile(fileAddress.FilePath);
                        Image thumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
                        var newPath = Path.ChangeExtension(fileAddress.FilePath, "thumb");
                        thumb.Save(newPath);
                        issue.FileId = fileAddress.FileId;
                        fileAddress.FilePath = newPath;
                        fileAddress.FileType = "thumb";
                        _context.FileAddresses.Update(fileAddress);
                    }
                    catch (Exception ex)
                    {

                        throw new ExperienceManagementGlobalException(IssueServiceErrors.ChangeToThumbnailError, ex);
                    }

                }
                var IsExistEquipment = _context.Equipments.All(c => issueForm.EquipmentIds.Contains(c.Id));
                if (!IsExistEquipment)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.NotExistEquipmentsListError);
                }
                var equipmentIssueSubscriptionsRemove = await _context.EquipmentIssueSubscriptions.Where(c => c.IssueId == issue.Id).ToListAsync();

                var oldequipmentIssueSubscription = equipmentIssueSubscriptionsRemove.Select(c => c.Id).ToList();

                IEnumerable<long> differencesFirst = issueForm.EquipmentIds.Except(oldequipmentIssueSubscription).Union(oldequipmentIssueSubscription.Except(issueForm.EquipmentIds));
                IEnumerable<long> differencesSecond = issueForm.EquipmentIds.Union(oldequipmentIssueSubscription).Except(issueForm.EquipmentIds.Intersect(oldequipmentIssueSubscription));
                if (differencesFirst.Count() > 0 || differencesSecond.Count() > 0)
                {
                    _context.EquipmentIssueSubscriptions.RemoveRange(equipmentIssueSubscriptionsRemove);
                    issueForm.EquipmentIds.ForEach(async resp =>
                    {
                        var equipmentIssueSubscription = new EquipmentIssueSubscription();
                        equipmentIssueSubscription.IssueId = issue.Id;
                        equipmentIssueSubscription.EquipmentId = resp;
                        await _context.EquipmentIssueSubscriptions.AddAsync(equipmentIssueSubscription);
                    });
                }


                issue.IssueType = (IssueType)issueForm.IssueType;
                issue.Title = issueForm.Title;
                issue.Description = issue.Description;
                issue.LastUpdateDate = DateTime.Now;
                _context.Issues.Update(issue);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(IssueServiceErrors.EditIssueError, ex);
            }
        }

        public async Task<bool> EditIssueDetailAsync(User user, EditIssueDetailFormModel issueDetailForm)
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
                var issueDetail = await _context.IssueDetails.FindAsync(issueDetailForm.IssueDetailId);
                if (issueDetail is null)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.IssueDetailNotFoundError);
                }
                issue.LastUpdateDate = DateTime.Now;
                issueDetail.LastUpdateDate = DateTime.Now;
                issueDetail.Caption = issueDetailForm.Caption;
                issueDetail.Text = issueDetailForm.Text;
                _context.IssueDetails.Update(issueDetail);
                _context.Issues.Update(issue);

                if (issueDetailForm.UploadFiles != null && issueDetailForm.UploadFiles.Count > 0)
                {
                    var notFoundFiles = 0;
                    var filesAddress = new List<FileAddress>();
                    issueDetailForm.UploadFiles.ForEach(uf =>
                   {
                       var fileAddress = _context.FileAddresses.Find(uf);
                       if (fileAddress == null)
                       {
                           notFoundFiles++;
                       }
                       filesAddress.Add(fileAddress);
                   });
                    if (notFoundFiles > 0)
                    {
                        throw new ExperienceManagementGlobalException(IssueServiceErrors.NotExistFileAddressError);
                    }

                    filesAddress.ForEach(async fa =>
                    {
                        var issueDetailAttachment = new IssueDetailAttachment()
                        {
                            IssueDetailId = issueDetail.Id,
                            FileId = fa.FileId,
                            FileSize = fa.FileSize,
                            FileType = fa.FileType,
                        };
                        await _context.IssueDetailAttachments.AddAsync(issueDetailAttachment);
                    });
                }
                await _context.SaveChangesAsync();
                return true;


            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(IssueServiceErrors.EditIssueDetailError, ex);
            }
        }

        public async Task<bool> DeleteIssueDetailAttachmentsAsync(User user, DeleteIssueDetailFormModel issueDetailAttachmentForm)
        {
            try
            {
                var issueDetailAttachment = await _context.IssueDetailAttachments.FindAsync(issueDetailAttachmentForm.IssueDetailAttachId);
                if (issueDetailAttachment is null)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.IssueDetailAttachmentNotFoundError);
                }

                _context.IssueDetailAttachments.Remove(issueDetailAttachment);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(IssueServiceErrors.DeleteIssueDetailAttachmentsError, ex);
            }
        }

        public async Task<long> AddIssueDetailCommentAsync(User user, AddIssueDetailCommentFormModel issueForm)
        {
            try
            {
                var issueDetail = await _context.IssueDetails.FindAsync(issueForm.IssueDetailId);
                if (issueDetail is null)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.IssueDetailNotFoundError);
                }
                var userReq = await _context.Users.FindAsync(issueForm.UserId);
                if (userReq is null)
                {
                    throw new ExperienceManagementGlobalException(UsersServiceErrors.UserNotFoundError);
                }
                var issueDetailComment = new IssueDetailComment()
                {
                    Comment = issueForm.Comment,
                    CreationDate = DateTime.Now,
                    IssueDetailId = issueDetail.Id,
                    UserId = userReq.Id
                };
                await _context.IssueDetailComments.AddAsync(issueDetailComment);

                return issueDetailComment.Id;
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(IssueServiceErrors.AddIssueDetailCommentError, ex);
            }
        }

        public async Task<SearchIssueViewModel> GetIssuesForUserAsync(SearchIssueFormModel searchIssueForm)
        {
            try
            {
                var queryable = _context.Issues.Include(c => c.EquipmentIssueSubscriptions).Include(c => c.User).AsQueryable();

                if (!string.IsNullOrEmpty(searchIssueForm.Title))
                {
                    queryable = queryable.Where(q => q.Title.Contains(searchIssueForm.Title));
                }

                if (searchIssueForm.IssueType.HasValue)
                {
                    queryable = queryable.Where(q => q.IssueType == searchIssueForm.IssueType);
                }

                if (searchIssueForm.IsActive.HasValue)
                {
                    queryable = queryable.Where(q => q.IsActive == searchIssueForm.IsActive);
                }
                if (searchIssueForm.UserId.HasValue)
                {
                    queryable = queryable.Where(q => q.UserId == searchIssueForm.UserId);
                }
                if (searchIssueForm.EquipmentIds.Count > 0)
                {
                    //var eqIssueSubs = _context.EquipmentIssueSubscriptions.Where(c => searchIssueForm.EquipmentIds.Contains(c.EquipmentId)).Select(c=>c.IssueId).ToList();
                    queryable = queryable.Where(c => c.EquipmentIssueSubscriptions.Any(x => searchIssueForm.EquipmentIds.Contains(x.EquipmentId)));
                }
                if (searchIssueForm.SortModel != null)
                    switch (searchIssueForm.SortModel.Col + "|" + searchIssueForm.SortModel.Sort)
                    {
                        case "creationdate|asc":
                            queryable = queryable.OrderBy(x => x.CreationDate);
                            break;
                        case "creationdate|desc":
                            queryable = queryable.OrderByDescending(x => x.CreationDate);
                            break;

                        default:
                            queryable = queryable.OrderBy(x => x.CreationDate);
                            break;
                    }
                else
                    queryable = queryable.OrderBy(x => x.CreationDate);
                var response = await queryable.Skip((searchIssueForm.PageIndex - 1) * searchIssueForm.PageSize).Take(searchIssueForm.PageSize).ToListAsync();
                var count = await queryable.CountAsync();
                var searchViewModel = new SearchIssueViewModel();

                searchViewModel.searchIssueViewModel = response.Select(resp => new IssueViewModel()
                {
                    Id = resp.Id,
                    AnswerCount = resp.AnswerCounts,
                    CreationDate = resp.CreationDate,
                    Description = resp.Description,
                    Equipments = resp.EquipmentIssueSubscriptions.Select(x => new EquipmentViewModel()
                    {
                        Description = x.Equipment.Description,
                        EquipmentName = x.Equipment.EquipmentName,
                        Id = x.EquipmentId
                    }).ToList(),
                    IsActive = resp.IsActive,
                    SumLikes = resp.IssueDetails.Sum(c => c.Likes),
                    IssueType = resp.IssueType,
                    LastUpdateDate = resp.LastUpdateDate,
                    Title = resp.Title,
                    UserId = resp.UserId,
                    UserName = resp.User.Username,
                    FileId = resp.FileId

                }).ToList();
                searchViewModel.PageIndex = searchIssueForm.PageIndex;
                searchViewModel.PageSize = searchIssueForm.PageSize;
                searchViewModel.TotalCount = count;
                return searchViewModel;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(IssueServiceErrors.GetIssuesError, ex);
            }
        }

        public async Task<List<IssueDetailViewModel>> GetIssueDetailsAsync(SearchIssueDetailFormModel searchIssueDetailForm)
        {
            try
            {
                var querable = _context.IssueDetails.Include(c => c.User).Include(c => c.IssueDetailComments).Include(c => c.IssueDetailAttachments).Where(c => c.IssueId == searchIssueDetailForm.IssueId).AsQueryable();
                if (searchIssueDetailForm.IssueDetailsId.HasValue)
                {
                    querable = querable.Where(c => c.Id == searchIssueDetailForm.IssueDetailsId);
                }
                var resp = await querable.ToListAsync();
                if (resp is null)
                {
                    throw new ExperienceManagementGlobalException(IssueServiceErrors.IssueNotFoundError);
                }
                var issueDetailViewModel = new List<IssueDetailViewModel>();
                resp.ForEach(response =>
                {

                    var issuedetail = new IssueDetailViewModel()
                    {
                        Caption = response.Caption,
                        AnswerUseful = response.AnswerUseful,
                        CreationDate = response.CreationDate,
                        Text = response.Text,
                        IsCorrectAnswer = response.IsCorrectAnswer,
                        IssueId = response.IssueId,
                        Likes = response.Likes,
                        IssueDetailId = response.Id,
                        UserId = response.UserId,
                        UserName = response.User.Username,
                        LastUpdateDate = response.LastUpdateDate,
                        IssueDetailComments=new List<IssueDetailCommentViewModel>(),
                        IssueDetailAttachments=new List<IssueDetailAttachmentViewModel>()
                        
                };
                    response.IssueDetailComments.ToList().ForEach(c =>
                    {
                        var IssueDetailComment = new IssueDetailCommentViewModel()
                        {
                            Comment = c.Comment,
                            CreationDate = c.CreationDate,
                            IssueDetailId = c.IssueDetailId,
                            Id = c.Id,
                            UserId = c.UserId,
                            UserName = c.User.Username
                        };
                        issuedetail.IssueDetailComments.Add(IssueDetailComment);

                    });
                    response.IssueDetailAttachments.ToList().ForEach(c =>
                    {
                        var IssueDetailAtt = new IssueDetailAttachmentViewModel()
                        {
                            FileSize = c.FileSize,
                            FileType=c.FileType,
                            FileId = c.FileId,
                            IssueDetailId = c.IssueDetailId,
                            Id = c.Id,
                        };
                        issuedetail.IssueDetailAttachments.Add(IssueDetailAtt);

                    });



                });

                return issueDetailViewModel;
            }
            catch (Exception ex)
            {

                throw new ExperienceManagementGlobalException(IssueServiceErrors.GetIssueDetailsError, ex);
            }
        }

        public async  Task<SearchIssueViewModel> SearchSmartIssueAsync(SearchSmartIssueFormModel searchIssueForm)
        {
            try
            {
                var queryable = _context.Issues.Include(c => c.EquipmentIssueSubscriptions).Include(c=>c.IssueDetails).Include(c => c.User).AsQueryable();

                if (!string.IsNullOrEmpty(searchIssueForm.SearchContent))
                {
                    var searchContents = searchIssueForm.SearchContent.Split(" ");
                    queryable = queryable.Where(q => searchContents.Contains(q.Title));
                }

                if (searchIssueForm.FilterType.HasValue)
                {
                    if (searchIssueForm.FilterType.Value==FilterType.AcceptedAnswer)
                    {
                        queryable = queryable.Where(q => q.IssueDetails.Any(c=>c.IsCorrectAnswer));
                    }
                    else if (searchIssueForm.FilterType.Value == FilterType.NoAcceptedAnswer)
                    {
                        queryable = queryable.Where(q => q.IssueDetails.All(c => !c.IsCorrectAnswer));
                    }
                    else if (searchIssueForm.FilterType.Value == FilterType.NoAnswers)
                    {
                        queryable = queryable.Where(q => q.AnswerCounts>1);
                    }

                }

                if (searchIssueForm.SortType.HasValue)
                {
                    if (searchIssueForm.SortType.Value==SortType.Newest)
                    queryable = queryable.OrderByDescending(q => q.CreationDate);
                    else if (searchIssueForm.SortType.Value == SortType.MostLikes)
                        queryable = queryable.OrderByDescending(q => q.IssueDetails.Sum(x=>x.Likes));
                    else if (searchIssueForm.SortType.Value == SortType.RecentActivity)
                        queryable = queryable.OrderByDescending(q => q.IssueDetails.OrderByDescending(c=>c.LastUpdateDate));
                }
                if (searchIssueForm.UserId.HasValue)
                {
                    queryable = queryable.Where(q => q.UserId == searchIssueForm.UserId);
                }
                if (searchIssueForm.EquipmentIds.Count > 0)
                {
                    queryable = queryable.Where(c => c.EquipmentIssueSubscriptions.Any(x => searchIssueForm.EquipmentIds.Contains(x.EquipmentId)));
                }
               
                var response = await queryable.Skip((searchIssueForm.PageIndex - 1) * searchIssueForm.PageSize).Take(searchIssueForm.PageSize).ToListAsync();
                var count = await queryable.CountAsync();
                var searchViewModel = new SearchIssueViewModel();

                searchViewModel.searchIssueViewModel = response.Select(resp => new IssueViewModel()
                {
                    Id = resp.Id,
                    AnswerCount = resp.AnswerCounts,
                    CreationDate = resp.CreationDate,
                    Description = resp.Description,
                    Equipments = resp.EquipmentIssueSubscriptions.Select(x => new EquipmentViewModel() {
                                               Description =x.Equipment.Description,EquipmentName=x.Equipment.EquipmentName,Id=x.EquipmentId }).ToList(),
                    IsActive = resp.IsActive,
                    IssueType = resp.IssueType,
                    LastUpdateDate = resp.LastUpdateDate,
                    Title = resp.Title,
                    SumLikes=resp.IssueDetails.Sum(c=>c.Likes),
                    UserId = resp.UserId,
                    UserName = resp.User.Username,
                    FileId = resp.FileId

                }).ToList();
                searchViewModel.PageIndex = searchIssueForm.PageIndex;
                searchViewModel.PageSize = searchIssueForm.PageSize;
                searchViewModel.TotalCount = count;
                return searchViewModel;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(IssueServiceErrors.SearchIssuesError, ex);
            }
        }
    }
}
