namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.RepositoryUow
{
    public class RepositoryUowErrors
    {
        public static readonly ExperienceManagementErrorMessage Commit =
            new ExperienceManagementErrorMessage("RUOW-1000", "هنگام commit تراکنش خطایی رخ داده است");
        public static readonly ExperienceManagementErrorMessage Rollback =
            new ExperienceManagementErrorMessage("RUOW-1001", "هنگام Rollback تراکنش خطایی رخ داده است");
        public static readonly ExperienceManagementErrorMessage Dispose =
            new ExperienceManagementErrorMessage("RUOW-1002", "هنگام dispose کردن UOW خطایی رخ داده است");
    }
}
