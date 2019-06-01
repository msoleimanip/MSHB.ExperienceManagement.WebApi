using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L02_DataLayer;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Extensions;
using Microsoft.EntityFrameworkCore;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;

namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Implement
{
    public class DbEquipmentRepository : IEquipmentRepository
    {
        private readonly ExperienceManagementDbContext _uow;
        public DbEquipmentRepository(ExperienceManagementDbContext uow)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));
        }
        public async Task<long> AddEquipmentAsync(User user, string EquipmentName, string description, long? parentId)
        {
            try
            {
                Equipment parent = null;
                if (parentId != null)
                    parent = _uow.Equipments.FirstOrDefault(c => c.ParentId == parentId);                         
                    var isDuplicateEquipment = _uow.Equipments.Any(c => c.EquipmentName == EquipmentName);
                    if (!isDuplicateEquipment)
                    {
                        var org = new Equipment()
                        {
                            Description = description,
                            EquipmentName = EquipmentName,
                            ParentId = parentId
                        };
                        await _uow.Equipments.AddAsync(org);
                        await _uow.SaveChangesAsync();
                        return org.Id;
                    }
                    throw new ExperienceManagementGlobalException(EquipmentRepositoryErrors.DbAddDuplicateEquipmentError);                             
            }

            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentRepositoryErrors.DbAddEquipmentError, ex);
            }
        }

        public async Task<bool> DeleteEquipmentAsync(User user, List<long> equipmentIds)
        {
            try
            {                
                foreach (var equipmentid in equipmentIds)
                {
                    //if (_uow.Users.Any(c => c.EquipmentId == equipmentid))
                    //{
                    //    throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.UserInOrganizationExistError);
                    //}
                    var parent = _uow.Equipments.Include(p => p.Children)
                               .SingleOrDefault(p => p.Id == equipmentid);

                    foreach (var child in parent.Children.ToList())
                    {
                        if (!equipmentIds.Contains(child.Id))
                        {
                            throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.DeleteOrgNotselectedError);
                        }
                        await DeleteOrganizationByChildAsync(child, equipmentIds);
                        _uow.Equipments.Remove(child);
                    }
                    _uow.Equipments.Remove(parent);                    
                }
                _uow.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentRepositoryErrors.DbDeleteEquipmentError, ex);
            }
        }

        private async Task DeleteOrganizationByChildAsync(Equipment child,List<long> equipmentIds)
        {
            //if (_uow.Users.Any(c => c.EquipmentId == child.Id))
            //{
            //    throw new ExperienceManagementGlobalException(OrganizationRepositoryErrors.UserInOrganizationExistError);
            //}
            var parentEquipment = _uow.Equipments.Include(p => p.Children)
                       .SingleOrDefault(p => p.Id == child.Id);

            foreach (var childEquipment in parentEquipment.Children.ToList())
            {
                if (!equipmentIds.Contains(childEquipment.Id))
                {
                    throw new ExperienceManagementGlobalException(EquipmentRepositoryErrors.DeleteEquipmentNotselectedError);
                }
                await DeleteOrganizationByChildAsync(childEquipment, equipmentIds);
                _uow.Equipments.Remove(child);
            }
        }

        public async Task<bool> EditEquipmentAsync(User user, long equipmentId, string equipmentName, string description, long? parentId)
        {
            try
            {
                Equipment equipment = null;
                equipment = _uow.Equipments.FirstOrDefault(c => c.Id == equipmentId);
                if (equipment != null)
                {
                    var isDuplicateEquipment = _uow.Equipments.Any(c => c.EquipmentName == equipmentName && c.Id != equipmentId);
                    if (!isDuplicateEquipment)
                    {
                        equipment.Description = description;
                        equipment.EquipmentName = equipmentName;
                        equipment.ParentId = parentId;
                        equipment.LastUpdateDate = DateTime.Now;
                        _uow.Equipments.Update(equipment);
                        await _uow.SaveChangesAsync();
                        return true;
                    }
                    throw new ExperienceManagementGlobalException(EquipmentRepositoryErrors.DbEditDuplicateEquipmentError);
                }
                throw new ExperienceManagementGlobalException(EquipmentRepositoryErrors.DbEditEquipmentNotExistError);
            }

            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentRepositoryErrors.DbEditEquipmentError, ex);
            }
        }

        public async Task<List<Equipment>> GetEquipmentByUserAsync(User user)
        {
            if (user.IsAdmin())
            {
                var equipments = await _uow.Equipments.ToListAsync();
                return equipments;
            }
            else
            {
                return new List<Equipment>();
            }
           
        }

       
    }
}
