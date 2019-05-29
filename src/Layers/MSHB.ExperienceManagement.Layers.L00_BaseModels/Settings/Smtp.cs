namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Settings
{
    public class Smtp
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public string LocalDomain { get; set; }
        public bool UsePickupFolder { get; set; }
        public string PickupFolder { get; set; }
        public string FromName { get; set; }
        public string FromAddress { get; set; }
    }
}