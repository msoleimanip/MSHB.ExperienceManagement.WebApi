namespace MSHB.ExperienceManagement.Layers.L00_BaseModels.Constants.Messages.Base
{
    public class BaseRepositoryErrors
    {
        public static readonly ExperienceManagementErrorMessage InternalCommit =
            new ExperienceManagementErrorMessage("RBA-1000", "هنگام commit تراکنش داخلی خطایی رخ داده است");
        public static readonly ExperienceManagementErrorMessage InternalRollback =
            new ExperienceManagementErrorMessage("RBA-1001", "هنگام Rollback تراکنش داخلی خطایی رخ داده است");
    }
}
