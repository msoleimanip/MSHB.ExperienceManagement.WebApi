﻿using MSHB.ExperienceManagement.Layers.L01_Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L01_Entities.Models
{
    [Table("User_T")]

    public class User
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
            EquipmentUserSubscriptions = new HashSet<EquipmentUserSubscription>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(500)]
        public string Username { get; set; }

        public string Password { get; set; }

        [MaxLength(500)]
        public string FirstName { get; set; }
        [MaxLength(500)]
        public string LastName { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Location { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime? LastLockoutDate { get; set; }

        public DateTime? LastPasswordChangedDate { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime? LastVisit { get; set; }


        public bool IsActive { get; set; }

        public DateTimeOffset? LastLoggedIn { get; set; }

        [MaxLength(50)]
        public string SerialNumber { get; set; }

        [MaxLength(200)]
        public string SajadUserName { get; set; }

        public PresidentType? IsPresident { get; set; }

        [ForeignKey("GroupAuthId")]
        public long? GroupAuthId { get; set; }

        public virtual GroupAuth GroupAuth { get; set; }


        [ForeignKey("OrganizationId")]
        public long? OrganizationId { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserToken> UserTokens { get; set; }

        [ForeignKey("UserConfigurationId")]
        public long? UserConfigurationId { get; set; }

        public virtual ICollection<UserConfiguration> UserConfigurations { get; set; }

        public virtual ICollection<EquipmentUserSubscription> EquipmentUserSubscriptions { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }

        public virtual ICollection<IssueDetail> IssueDetails { get; set; }

        public virtual ICollection<UserIssueSubscription> UserIssueSubscriptions { get; set; }

        public virtual ICollection<IssueDetailComment> IssueDetailComments { get; set; }




    }
}
