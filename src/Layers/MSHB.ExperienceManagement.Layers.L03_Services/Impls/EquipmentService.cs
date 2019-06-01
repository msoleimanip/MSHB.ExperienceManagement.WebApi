using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.exceptions;
using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using MSHB.ExperienceManagement.Layers.L03_Services.Contracts;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.InputForms;
using MSHB.ExperienceManagement.Layers.L04_ViewModels.Tree;
using MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts;
using MSHB.ExperienceManagement.Shared.Common.GuardToolkit;
using MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base;

namespace MSHB.ExperienceManagement.Layers.L03_Services.Impls
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IEquipmentRepository _equipmentRepository;


        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
            _equipmentRepository.CheckArgumentIsNull(nameof(_equipmentRepository));
        }
      
        public async Task<List<JsTreeNode>> GetEquipmentByUserAsync(User user)
        {
            var equipments = await _equipmentRepository.GetEquipmentByUserAsync(user);
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
                var orgId = await _equipmentRepository.AddEquipmentAsync(user, equipmentForm.EquipmentName, equipmentForm.Description, equipmentForm.ParentId);
                return orgId;
            }
            catch(Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.AddEquipmentError, ex);
            }

           
        }     

        public async Task<bool> EditEquipmentAsync(User user, EditEquipmentFormModel equipmentForm)
        {
            try
            {
                var res = await _equipmentRepository.EditEquipmentAsync(user, equipmentForm.EquipmentId, equipmentForm.EquipmentName, equipmentForm.Description, equipmentForm.ParentId);
                return res;
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
                var res = await _equipmentRepository.DeleteEquipmentAsync(user, equipmentIds);
                return res;
            }
            catch (Exception ex)
            {
                throw new ExperienceManagementGlobalException(EquipmentServiceErrors.DeleteEquipmentError, ex);
            }
        }

    }
}
