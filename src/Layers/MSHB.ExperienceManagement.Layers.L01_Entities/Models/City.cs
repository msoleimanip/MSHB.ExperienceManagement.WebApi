using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("City_T")]

    public class City:BaseEntity
    {

        [DataType(DataType.Text), MaxLength(100)]
        public string Name { get; set; }

        public long? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual City Parent { get; set; }

        public virtual ICollection<City> Children { get; set; }
    }
}
