using System;

namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Settings
{
    public class CookieOptions
    {
        public string AccessDeniedPath { get; set; }
        public string CookieName { get; set; }
        public TimeSpan ExpireTimeSpan { get; set; }
        public string LoginPath { get; set; }
        public string LogoutPath { get; set; }
        public bool SlidingExpiration { get; set; }
        public bool UseDistributedCacheTicketStore { set; get; }
        public DistributedSqlServerCacheOptions DistributedSqlServerCacheOptions { set; get; }
    }
}