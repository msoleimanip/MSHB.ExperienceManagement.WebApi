using MSHB.ExperienceManagement.Layers.L01_Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MSHB.ExperienceManagement.Layers.L05_RepositoryLayer.Repository.Contracts
{
    public interface IEquipmentRepository
    {       
        Task<List<Equipment>> GetEquipmentByUserAsync(User user);
        Task<Equipment> GetEquipmentByIdAsync(User user, long equipmentId);
        Task<bool> DeleteEquipmentAsync(User user, List<long> equipmentIds);
        Task<long> AddEquipmentAsync(User user, string equipmentName, string description, long? parentId);
        Task<bool> EditEquipmentAsync(User user, long equipmentId, string equipmentName, string description, long? parentId);
    }
}
