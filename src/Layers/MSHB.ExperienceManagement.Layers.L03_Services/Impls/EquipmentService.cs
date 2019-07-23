using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.Tree;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Extensions;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ExperienceManagementDbContext _context;

        public EquipmentService(ExperienceManagementDbContext context)
        {
            _context = context;
            _context.CheckArgumentIsNull(nameof(_context));
        }
        public async Task<EquipmentViewModel> GetAsync(User user, long Id)
        {
            Equipment equipment;
            try
            {
                equipment = await _context.Equipments.FindAsync(Id);

            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.GetEquipmentError, ex);
            }

            if (equipment != null)
            {
                return new EquipmentViewModel()
                {
                    Id = equipment.Id,
                    EquipmentName = equipment.EquipmentName,
                    Description = equipment.Description,
                    ParentId = equipment.ParentId
                };
            }

            throw new ExperienceManagementGlobalException(EquipmentServiceErrors.EquipmentNotFoundError);
        }
        public async Task<List<JsTreeNode>> GetEquipmentByUserAsync(User user)
        {
            var equipments = new List<Equipment>();

            if (user.IsAdmin())
            {
                equipments = await _context.Equipments.ToListAsync();

            }
            else
            {
                equipments = await _context.EquipmentUserSubscriptions.Where(c => c.UserId == user.Id).Select(c => c.Equipment).ToListAsync();

            }
            var equipmentnodes = new List<JsTreeNode>();
            equipments.ForEach(or =>
            {
                if (or.ParentId == null)
                {
                    JsTreeNode parentNode = new JsTreeNode();
                    parentNode.id = or.Id.ToString();
                    parentNode.text = or.EquipmentName;
                    parentNode = FillChild(equipments, parentNode, or.Id);
                    equipmentnodes.Add(parentNode);
                }

            });
            return equipmentnodes;
        }
        private JsTreeNode FillChild(List<Equipment> equipments, JsTreeNode parentNode, long Id)
        {
            if (equipments.Count > 0)
            {
                equipments.ForEach(or =>
                {
                    if (or.ParentId == Id)
                    {
                        JsTreeNode parentNodeChild = new JsTreeNode();
                        parentNodeChild.id = or.Id.ToString();
                        parentNodeChild.text = or.EquipmentName;
                        parentNode.children.Add(parentNodeChild);
                        FillChild(equipments, parentNodeChild, or.Id);
                    }
                });
            }
            return parentNode;
        }
        public async Task<long> AddEquipmentAsync(User user, AddEquipmentFormModel equipmentForm)
        {
            try
            {
                Equipment parent = null;
                if (equipmentForm.ParentId != null)
                    parent = _context.Equipments.FirstOrDefault(c => c.ParentId == equipmentForm.ParentId);
                var isDuplicateEquipment = _context.Equipments.Any(c => c.EquipmentName == equipmentForm.EquipmentName);
                if (!isDuplicateEquipment)
                {
                    var org = new Equipment()
                    {
                        Description = equipmentForm.Description,
                        EquipmentName = equipmentForm.EquipmentName,
                        ParentId = equipmentForm.ParentId
                    };
                    await _context.Equipments.AddAsync(org);
                    await _context.SaveChangesAsync();
                    return org.Id;
                }
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.AddDuplicateEquipmentError);


            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.AddEquipmentError, ex);
            }


        }

        public async Task<bool> EditEquipmentAsync(User user, EditEquipmentFormModel equipmentForm)
        {
            try
            {
                Equipment equipment = null;
                equipment = _context.Equipments.FirstOrDefault(c => c.Id == equipmentForm.EquipmentId);
                if (equipment != null)
                {
                    var isDuplicateEquipment = _context.Equipments.Any(c => c.EquipmentName == equipmentForm.EquipmentName && c.Id != equipmentForm.EquipmentId);
                    if (!isDuplicateEquipment)
                    {
                        equipment.Description = equipmentForm.Description;
                        equipment.EquipmentName = equipmentForm.EquipmentName;
                        equipment.ParentId = equipmentForm.ParentId;
                        equipment.LastUpdateDate = DateTime.Now;
                        _context.Equipments.Update(equipment);
                        await _context.SaveChangesAsync();
                        return true;
                    }
                    throw new ExperienceManagementGlobalException(EquipmentServiceErrors.EditDuplicateEquipmentError);
                }
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.EditEquipmentNotExistError);
            }

            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.EditEquipmentError, ex);
            }

        }

        public async Task<bool> DeleteEquipmentAsync(User user, List<long> equipmentIds)
        {
            try
            {
                foreach (var equipmentid in equipmentIds)
                {
                    if (_context.EquipmentUserSubscriptions.Any(c => c.EquipmentId == equipmentid))
                    {
                        throw new ExperienceManagementGlobalException(EquipmentServiceErrors.UserInEquipmentExistError);
                    }
                    var parent = _context.Equipments.Include(p => p.Children)
                               .SingleOrDefault(p => p.Id == equipmentid);

                    foreach (var child in parent.Children.ToList())
                    {
                        if (!equipmentIds.Contains(child.Id))
                        {
                            throw new ExperienceManagementGlobalException(EquipmentServiceErrors.DeleteEquipmentNotselectedError);
                        }
                        await DeleteEquipmentByChildAsync(child, equipmentIds);
                        _context.Equipments.Remove(child);
                    }
                    _context.Equipments.Remove(parent);
                }
                _context.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.DeleteEquipmentError, ex);
            }
        }
        private async Task DeleteEquipmentByChildAsync(Equipment child, List<long> equipmentIds)
        {

            var parentEquipment = _context.Equipments.Include(p => p.Children)
                       .SingleOrDefault(p => p.Id == child.Id);

            foreach (var childEquipment in parentEquipment.Children.ToList())
            {
                if (!equipmentIds.Contains(childEquipment.Id))
                {
                    throw new ExperienceManagementGlobalException(EquipmentServiceErrors.DeleteEquipmentNotselectedError);
                }
                await DeleteEquipmentByChildAsync(childEquipment, equipmentIds);
                _context.Equipments.Remove(child);
            }
        }

        public async Task<List<JsTreeNode>> GetUserEquipmentForUserAsync(User user, Guid userId)
        {
            var userEquipmentIds = (await _context.Users.Include(c => c.EquipmentUserSubscriptions).FirstOrDefaultAsync(c => c.Id == userId))?.EquipmentUserSubscriptions.Select(c => c.EquipmentId).ToList();
            var equipments = new List<Equipment>();
            equipments = await _context.Equipments.ToListAsync();

            var equipmentUsers = equipments.Where(x => userEquipmentIds.Contains(x.Id)).ToList();

            var equipmentnodes = new List<JsTreeNode>();
            equipments.ForEach(eq =>
            {
                if (eq.ParentId == null)
                {
                    JsTreeNode parentNode = new JsTreeNode();
                    parentNode.id = eq.Id.ToString();
                    parentNode.text = eq.EquipmentName;
                    if (equipmentUsers.Contains(eq))
                    {
                        parentNode.state.selected = true;

                    }
                    parentNode = FillChild(equipments, parentNode, eq.Id, equipmentUsers);
                    equipmentnodes.Add(parentNode);
                }

            });
            return equipmentnodes;
        }

        private JsTreeNode FillChild(List<Equipment> equipments, JsTreeNode parentNode, long eqId, List<Equipment> equipmentUsers)
        {
            if (equipments.Count > 0)
            {
                equipments.ForEach(eq =>
                {

                    if (eq.ParentId == eqId)
                    {
                        JsTreeNode parentNodeChild = new JsTreeNode();
                        parentNodeChild.id = eq.Id.ToString();
                        parentNodeChild.text = eq.EquipmentName;
                        if (equipmentUsers.Contains(eq))
                        {
                            parentNodeChild.state.selected = true;

                        }
                        parentNode.children.Add(parentNodeChild);
                        FillChild(equipments, parentNodeChild, eq.Id, equipmentUsers);
                    }
                });
            }
            return parentNode;
        }

        public async Task<EquipmentAttachmentViewModel> AddEquipmentAttachmentAsync(User user, AddEquipmentAttachmentFormModel equipmentAttachmentForm)
        {
            try
            {
                Equipment equipment = null;
                equipment = _context.Equipments.FirstOrDefault(c => c.Id == equipmentAttachmentForm.EquipmentId);
                if (equipment != null)
                {

                    var isDuplicateEquipmentAtt = _context.EquipmentAttachments.Any(c => c.EquipmentId == equipmentAttachmentForm.EquipmentId && c.EquipmentAttachmentName == equipmentAttachmentForm.EquipmentAttachmentName && c.EquipmentAttachmentType == equipmentAttachmentForm.EquipmentAttachmentType);
                    if (!isDuplicateEquipmentAtt)
                    {
                        var equipmentAtt = new EquipmentAttachment()
                        {
                            Description = equipmentAttachmentForm.Description,
                            EquipmentAttachmentName = equipmentAttachmentForm.EquipmentAttachmentName,
                            EquipmentAttachmentType = equipmentAttachmentForm.EquipmentAttachmentType,
                            EquipmentId = equipmentAttachmentForm.EquipmentId,
                        };
                        if (equipmentAttachmentForm.UploadFileId != null)
                        {
                            var fileAddress = _context.FileAddresses.Find(equipmentAttachmentForm.UploadFileId);

                            if (fileAddress is null)
                            {
                                throw new ExperienceManagementGlobalException(IssueServiceErrors.NotExistFileAddressError);
                            }
                            equipmentAtt.FileId = fileAddress.FileId;
                            equipmentAtt.FileSize = fileAddress.FileSize;
                            equipmentAtt.FileType = fileAddress.FileType;

                        }
                        await _context.EquipmentAttachments.AddAsync(equipmentAtt);
                        await _context.SaveChangesAsync();
                        return new EquipmentAttachmentViewModel() {
                            EquipmentAttachmentId= equipmentAtt.Id,
                            CreationDate=equipmentAtt.CreationDate,
                            Description=equipmentAtt.Description,
                            EquipmentAttachmentName=equipmentAtt.EquipmentAttachmentName,
                            EquipmentId=equipmentAtt.EquipmentId,
                            EquipmentAttachmentType=equipmentAtt.EquipmentAttachmentType,
                            FileId=equipmentAtt.FileId,
                            FileSize=equipmentAtt.FileSize,
                            FileType=equipmentAtt.FileType
                        };
                    }
                    throw new ExperienceManagementGlobalException(EquipmentServiceErrors.AddDuplicateEquipmentAttachmentError);
                }
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.EditEquipmentNotExistError);


            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.AddEquipmentAttachmentError, ex);
            }
        }

        public Task<bool> EditEquipmentAttachmentAsync(User user, EditEquipmentAttachmentFormModel equipmentAttachmentForm)
        {
            throw new NotImplementedException();
        }

        public Task<EquipmentAttachmentViewModel> GetEquipmentAttachmentAsync(User user, long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EquipmentAttachmentViewModel>> GetEquipmentAttachmentForUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<EquipmentAttachmentViewModel>> GetEquipmentAttachmentByEquipmentIdAsync(User user, long id)
        {
            throw new NotImplementedException();
        }
    }
}
