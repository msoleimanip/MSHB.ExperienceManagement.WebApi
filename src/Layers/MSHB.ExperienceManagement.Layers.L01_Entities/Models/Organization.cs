using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("Organization_T")]
    public class Organization:BaseEntity
    {
        [DataType(DataType.Text), MaxLength(100)]
        public string OrganizationName { get; set; }

        public string Description { get; set; }
        public DateTime? CreationDate { get; set; }

        public long? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Organization Parent { get; set; }

        public virtual ICollection<Organization> Children { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
