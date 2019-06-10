using System;
using System.Collections.Generic;
using System.Text;

namespace MSHB.ExperienceManagement.Layers.L04_ViewModels.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }    
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public int? IsPresident { get; set; }
        public long? GroupAuthId { get; set; }
        public long? OrganizationId { get; set; }
        public long? UserConfigurationId { get; set; }
    }
}
